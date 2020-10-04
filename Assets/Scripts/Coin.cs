using UnityEngine;

public class Coin : MonoBehaviour
{
    // Coin value
    public int coinValue = 1;

    // Check if the player collided with the coin
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.ChangeScore(coinValue);
            FindObjectOfType<SoundManager>().Play("Coin");
            Destroy(this.gameObject);
        }
    }
}
