using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    // Define the wait time (in seconds)
    public float timeRemaining = 5;
    // Get the text object where the time will be shown
    public GameObject textCounter;

    // Text object where the time will be shown
    private TextMeshProUGUI text;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        text = textCounter.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // Decrease time
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        // Convert time into integer and fix the value
        text.text = ((int)timeRemaining + 1).ToString();
        // Delete the saved game and load the main menu
        if (timeRemaining <= 0)
        {
            SaveSystem.DeleteSave();
            SceneManager.LoadScene(0);
        }
    }
}
