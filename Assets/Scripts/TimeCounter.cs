using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimeCounter : MonoBehaviour {

  public float timeRemaining = 5;
  public GameObject textCounter;
  private TextMeshProUGUI text;

  void Awake() {
    text = textCounter.GetComponent<TextMeshProUGUI>();
  }

  void Update() {
    if (timeRemaining > 0) {
      timeRemaining -= Time.deltaTime;
    }
    text.text = ((int) timeRemaining).ToString();
    if (timeRemaining <= 0) {
      SaveSystem.DeleteSave();
      SceneManager.LoadScene(0);
    }
  }
}
