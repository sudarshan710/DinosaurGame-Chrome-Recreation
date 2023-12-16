using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    private PlayerController playerController;
    public TextMeshProUGUI textScore;

    private void Start()
    {
        playerController = PlayerController.Instance;

        if (playerController != null)
        {
            Debug.Log("Player Score: " + playerController.GetPlayerScore());

            // Assuming the TextMeshProUGUI component is on the same GameObject as this script
            textScore = GameObject.Find("YourScore")?.GetComponent<TextMeshProUGUI>();
            if (textScore != null)
            {
                textScore.text = "Your Score: " + Mathf.Round(playerController.GetPlayerScore());
            }
            else
            {
                Debug.LogError("TextMeshProUGUI not found!");
            }
        }
        else
        {
            Debug.LogError("PlayerController not found!");
        }
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene("GameScene");
    }
}
