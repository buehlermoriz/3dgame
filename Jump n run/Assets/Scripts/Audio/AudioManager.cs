using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    private string keyInput;

    private bool walkingActive = false;

    private bool shiftPressed = false;

    private bool jumpActive = false;

    private float horizontalInput;

    private float verticalInput;

    // Start is called before the first frame update
    void Awake()
    {

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void PlayLoop(string name)
    {

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound: '"+name+"' not found");
            return;
        }
        if (!s.isPlaying)
        {
            s.source.Play();
            s.isPlaying = true;
            s.source.loop = true;
        }
    }

    public void Play(string name)
    {

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound: '" + name + "' not found");
            return;
        }
        if (!s.isPlaying)
        {
            s.source.Play();
            s.isPlaying = true;
        }
    }


    public void Stop(string name)
    {

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound: '" + name + "' not found");
            return;
        }
        s.source.Stop();
        s.isPlaying = false;
    }

    //for playing reactive sounds
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //walking
        if (verticalInput != 0 || horizontalInput != 0)
        {

                walkingActive = true;
                if (!jumpActive)
                {
                    PlayLoop("walking");
                    print("start walking");
                }
            
            if (shiftPressed && walkingActive && !jumpActive)
            {
                //This happens if the player startet pressing shift before beginning to walk
                Stop("walking");
                PlayLoop("running");
            }
        }

        if (verticalInput == 0  && horizontalInput == 0)
        {

                Stop("walking");
                walkingActive = false;
                Stop("running");
                print("stop walking");
        }


        //jumping only is enabled when the player is currently not jumping but walking
        if (Input.GetKeyDown("space") && !jumpActive && walkingActive)
        {
            jumpActive = true;
            Play("jump");
            Stop("walking");
            Stop("running");
            print("start jump");

            StartCoroutine(ResumeSoundAfterJump(1.2f));
        }


        //running
        if (Input.GetKeyDown("left shift"))
        {
            shiftPressed = true;
            if (walkingActive && !jumpActive)
            {
                Stop("walking");
                PlayLoop("running");
                print("start running");
            }
        }

        if (Input.GetKeyUp("left shift"))
        {
            shiftPressed = false;
            if (walkingActive && !jumpActive)
            {
                Stop("running");
                PlayLoop("walking");
                print("stop running");
            } else
            {
                Stop("running");
                Stop("walking");
                print("stop running and walking");
            }
            

        }
    }

    IEnumerator ResumeSoundAfterJump(float time)
    {
        yield return new WaitForSeconds(time);
        
        Stop("jump");
        jumpActive = false;

        if (walkingActive && !shiftPressed)
        {
            PlayLoop("walking");
        }
        else if (walkingActive && shiftPressed)
        {
            PlayLoop("running");
        }
        print("stop jump");

    }
}
