using System;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour {
  // Singleton
  public static SoundManager instance;
  // List of sounds
  public Sound[] sounds;

  void Awake() {
    // Singleton
    if (instance == null) {
      instance = this;
    } else {
      Destroy(gameObject);
      return;
    }
    // Persist
    DontDestroyOnLoad(gameObject);
    // Add sounds
    foreach (Sound s in sounds) {
      s.source = gameObject.AddComponent<AudioSource>();
      s.source.clip = s.clip;
      s.source.volume = s.volume;
      s.source.pitch = s.pitch;
      s.source.loop = s.loop;
    }
  }

  void Start() {
    Play("Theme");
  }

  public void Play(string name) {
    // Get sound
    Sound s = Array.Find(sounds, sound => sound.name == name);
    // Play the sound if it exists
    if (s != null) { s.source.Play(); }
    // Print error message log
    else { Debug.Log("Sound: " + name + " not found!"); }
  }
}
