using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    private string keyInput;

    private int walkCounter;

    private bool walkingActive = false;

    private bool sprintActive = false;

    private bool shiftPressed = false;

    private bool jumpActive = false;

    // Start is called before the first frame update
    void Awake()
    {
        walkCounter = 0;

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
        //walking
        if (Input.GetKeyDown("w") || Input.GetKeyDown("a") || Input.GetKeyDown("d"))
        {
            walkCounter++;

            if (sprintActive == false)
            {
                walkingActive = true;
                PlayLoop("walking");
                print("start walking");
            }
            if (shiftPressed && walkingActive && !jumpActive)
            {
                //This happens if the player startet pressing shift before beginning to walk
                Stop("walking");
                walkingActive = false;
                PlayLoop("running");
                sprintActive = true;
            }
        }
        if (Input.GetKeyUp("w") || Input.GetKeyUp("a") || Input.GetKeyUp("d"))
        {
            walkCounter--;
            if (walkCounter == 0)
            {
                Stop("walking");
                walkingActive = false;
                Stop("running");
                sprintActive = false;
                print("stop walking");
            }
        }



        //jumping
        if (Input.GetKeyDown("space"))
        {
            jumpActive = true;
            Play("jump");
            Stop("walking");
            Stop("running");
            print("start jump");

            StartCoroutine(ResumeSoundAfterJump(1.2f));
        }

        if (Input.GetKeyUp("space"))
        {

        }

        //running
        if (Input.GetKeyDown("left shift"))
        {
            shiftPressed = true;
            if (walkingActive)
            {
                Stop("walking");
                sprintActive = true;
                PlayLoop("running");
                print("start running");
            }

        }

        if (Input.GetKeyUp("left shift"))
        {
            shiftPressed = false;
            if (walkingActive)
            {
                Stop("running");
                sprintActive = false;
                PlayLoop("walking");
                print("stop running");
            } else
            {
                Stop("running");
                sprintActive = false;
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

        if (walkingActive && sprintActive == false)
        {
            PlayLoop("walking");
        }
        else if (sprintActive)
        {
            PlayLoop("running");
        }
        print("stop jump");

    }



}
