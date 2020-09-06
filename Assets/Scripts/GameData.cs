using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData {
  public int score;
  public int level;

  public GameData(ScoreManager scoreManager, int levelID) {
    score = scoreManager.GetScore();
    level = levelID;
  }
}
