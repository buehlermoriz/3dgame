using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    private string keyInput;

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

    public void Play(string name)
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
            Play("walking");
            print("start walking");
        }
        if (Input.GetKeyUp("w") | Input.GetKeyUp("a") | Input.GetKeyUp("d"))
        {
            Stop("walking");
            print("stop walking");
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
            //Play("walking");
            print("stop jump");
        }

        //running
        if (Input.GetKeyDown("left shift"))
        {
            Stop("walking");
            Play("running");
            print("start running");
        }
        if (Input.GetKeyUp("left shift"))
        {
            Stop("running");
            Play("walking");
            print("stop running");
        }
    }



}
