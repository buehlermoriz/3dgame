using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    private string keyInput;

    private int walkCounter;

    private bool walkingActive = false;

    private bool sprintAcive = false;

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

            if (sprintAcive == false)
            {
                walkingActive = true;
                PlayLoop("walking");
                print("start walking");
            }
        }
        if (Input.GetKeyUp("w") || Input.GetKeyUp("a") || Input.GetKeyUp("d"))
        {
            walkCounter--;
            if (walkCounter == 0)
            {
                Stop("walking");
                walkingActive = false;
                print("stop walking");
            }
        }



        //jumping
        if (Input.GetKeyDown("space"))
        {
            Play("jump");
            Stop("walking");
            Stop("running");
            print("start jump");
        }
        if (Input.GetKeyUp("space"))
        {
            Stop("jump");
            if (walkingActive && sprintAcive == false)
            {
                PlayLoop("walking");
            } else if(sprintAcive)
            {
                PlayLoop("running");
            }
            print("stop jump");
        }

        //running
        if (Input.GetKeyDown("left shift") && walkingActive)
        {
           
            Stop("walking");
            sprintAcive = true;
            PlayLoop("running");
            print("start running");
            
        }

        if (Input.GetKeyUp("left shift") && walkingActive )
        {
            Stop("running");
            sprintAcive = false;
            PlayLoop("walking");
            print("stop running");
        }
    }



}
