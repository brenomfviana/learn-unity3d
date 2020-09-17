using System;
using UnityEngine;

public class InputManager : MonoBehaviour {
  // Get player
  public GameObject player;
  public GameObject pauseMenu;

  // Control if the game is paused or not
  bool isPaused = false;

  void Awake() {
    // Validate player interface
    if (!player is PlayerInterface) {
      throw new Exception("The given game object is not a PlayerInterface.");
    }
    pauseMenu.SetActive(false);
  }

  void Update() {
    // Get the player interface
    PlayerInterface plyr = player.GetComponent<PlayerInterface>();
    // Move player
    plyr.Move(Input.GetAxis("Horizontal"));
    // Check if the player pressed the jump button
    if (Input.GetButtonDown("Jump")) {
      plyr.Jump();
    }
    // Check if the player pressed the pause button
    if (Input.GetButtonDown("Submit")) {
      Pause();
    }
  }

  void Pause() {
    if (isPaused) {
      Time.timeScale = 1;
      pauseMenu.SetActive(false);
    } else {
      Time.timeScale = 0;
      pauseMenu.SetActive(true);
    }
    isPaused = !isPaused;
  }
}
