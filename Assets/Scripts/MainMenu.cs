using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

  public void NewGame() {
    SaveSystem.DeleteSave();
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }

  public void LoadGame() {
    GameData data = SaveSystem.LoadGame();
    if (data != null) {
      SceneManager.LoadScene(data.level + 1);
    } else {
      NewGame();
    }
  }

  public void ExitGame() {
    Application.Quit();
  }
}
