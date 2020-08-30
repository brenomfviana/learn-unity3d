using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound {
  // Sound name
  public string name;
  // Sound data
  public AudioClip clip;
  // Sound volume
  [Range(0f, 1f)]
  public float volume;
  // Sound pitch
  [Range(.1f, 3f)]
  public float pitch;
  // Loop
  public bool loop;
  // Sound source
  [HideInInspector]
  public AudioSource source;
}
