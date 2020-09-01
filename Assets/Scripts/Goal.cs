using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {
  private void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.CompareTag("Player")) {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
  }
}
