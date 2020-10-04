using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    // Score
    public int score;
    // The last completed level
    public int level;

    // Game data constructor.
    public GameData(ScoreManager scoreManager, int levelID)
    {
        score = scoreManager.Score;
        level = levelID;
    }
}
