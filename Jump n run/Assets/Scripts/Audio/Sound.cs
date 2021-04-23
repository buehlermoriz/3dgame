using UnityEngine.Audio;
using UnityEngine;
//based on a tutorial by Brackeys: https://www.youtube.com/watch?v=6OT43pvUyfY&t=605s


[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume=1;
    [Range(.1f, 3f)]
    public float pitch=1;

    [HideInInspector]
    public AudioSource source;

}
