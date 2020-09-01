using UnityEngine;
using UnityEngine.SceneManagement;

public class Abyss : MonoBehaviour {
  private void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.CompareTag("Player")) {
      // Destroy(other.gameObject);
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
  }
}
