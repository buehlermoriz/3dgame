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

        if (Input.GetKeyDown("w"))
        {
            Play("walking");
            print("start walking");
        }
        if (Input.GetKeyUp("w"))
        {
            Stop("walking");
            print("stop walking");
        }


        if (Input.GetKeyDown("space"))
        {
            Play("jump");
            print("start jump");
        }
        if (Input.GetKeyUp("space"))
        {
            Stop("jump");
            print("stop jump");
        }

    }



}
