using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI textScore;

    private void Start()
    {
     
        float playerScore = PlayerPrefs.GetFloat("PlayerScore", 0);
        Debug.Log("SAVED PLAYER SCORE: " +  playerScore);
        textScore = GameObject.Find("YourScore")?.GetComponent<TextMeshProUGUI>();
        if (textScore != null)
        {
            textScore.text = "Your Score: " + Mathf.Round(playerScore);
        }
        else
        {
            Debug.LogError("TextMeshProUGUI not found!");
        }

    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene("GameScene");
    }
}
