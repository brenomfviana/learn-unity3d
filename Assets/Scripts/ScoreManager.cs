using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Singleton
    public static ScoreManager instance;

    // Score text
    public Text text;

    // Score
    private int _score = 0;

    // Define the get method of `_score` attribute
    public int Score { get => _score; }

    // Update score value
    public void ChangeScore(int coinValue)
    {
        _score += coinValue;
        text.text = "x" + _score.ToString();
    }

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // Simulate the singleton
        if (instance == null)
        {
            GameData data = SaveSystem.LoadGame();
            if (data != null)
            {
                _score = data.score;
                text.text = "x" + _score.ToString();
            }
            instance = this;
        }
    }
}
