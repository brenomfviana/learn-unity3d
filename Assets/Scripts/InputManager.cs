using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Get player
    public GameObject player;
    public GameObject pauseMenu;

    // Control if the game is paused or not
    private bool isPaused = false;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // Validate the player interface
        if (player.GetComponent<PlayerInterface>() == null)
        {
            throw new Exception("The given game object is not a PlayerInterface.");
        }
        // Disable the pause menu
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Get the player interface
        PlayerInterface plyr = player.GetComponent<PlayerInterface>();
        // Move player
        plyr.Move(Input.GetAxis("Horizontal"));
        // Check if the player pressed the jump button
        if (Input.GetButtonDown("Jump"))
        {
            plyr.Jump();
        }
        // Check if the player pressed the pause button
        if (Input.GetButtonDown("Submit"))
        {
            Pause();
        }
    }

    // Turn on or turn off the pause and enable or disable the pause menu
    void Pause()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        isPaused = !isPaused;
    }
}
