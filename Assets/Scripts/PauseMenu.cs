using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Back to main menu
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
