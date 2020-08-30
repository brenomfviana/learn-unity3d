using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

  // Singleton
  public static ScoreManager instance;
  // Score text
  public Text text;
  // Score
  int score = 0;

  void Awake() {
    // Singleton
    if (instance == null) {
      instance = this;
    }
  }

  public void ChangeScore(int coinValue) {
    if (instance != null) {
      score += coinValue;
      text.text = "x" + score.ToString();
    }
  }
}
