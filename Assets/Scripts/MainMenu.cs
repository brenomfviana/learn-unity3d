using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Create a new game and delete the save
    public void NewGame()
    {
        SaveSystem.DeleteSave();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // If there is a saved game then load it, otherwise call the new game function
    public void LoadGame()
    {
        GameData data = SaveSystem.LoadGame();
        if (data != null)
        {
            SceneManager.LoadScene(data.level + 1);
        }
        else
        {
            NewGame();
        }
    }

    // Close the game
    public void ExitGame()
    {
        Application.Quit();
    }
}
