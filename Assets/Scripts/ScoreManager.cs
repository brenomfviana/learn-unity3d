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
      GameData data = SaveSystem.LoadGame();
      if (data != null) {
        score = data.score;
        text.text = "x" + score.ToString();
      }
      instance = this;
    }
  }

  public void ChangeScore(int coinValue) {
    score += coinValue;
    text.text = "x" + score.ToString();
  }

  public int GetScore() {
    return score;
  }
}
