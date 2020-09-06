using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

  public ScoreManager scoreManager;

  private void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.CompareTag("Player")) {
      // Save game
      int current = SceneManager.GetActiveScene().buildIndex;
      SaveSystem.SaveGame(scoreManager, current);
      // Load next level
      SceneManager.LoadScene(current + 1);
    }
  }
}
