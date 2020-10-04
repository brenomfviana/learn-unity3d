using System;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    // Singleton
    public static SoundManager instance;
    
    // List of sounds
    public Sound[] sounds;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // Simulate the singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        // Persist
        DontDestroyOnLoad(gameObject);
        // Add sounds
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    // Use this for initialization
    void Start()
    {
        Play("Theme");
    }

    // Play a music
    public void Play(string name)
    {
        // Get sound
        Sound s = Array.Find(sounds, sound => sound.name == name);
        // Play the sound if it exists
        if (s != null) { s.source.Play(); }
        // Print error message log
        else { Debug.Log("Sound: " + name + " not found!"); }
    }
}
