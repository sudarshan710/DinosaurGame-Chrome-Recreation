using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMaster : MonoBehaviour
{
    private PlayerController controller;
    public TextMeshProUGUI tmpText;

    private float highScore = 20;

    // Start is called before the first frame update
    void Start()
    {
        // Find the PlayerController component on the player GameObject
        controller = GameObject.FindObjectOfType<PlayerController>();

        // Find the TextMeshProUGUI component on the HighScoreUI GameObject
        tmpText = GameObject.Find("HighScoreUI")?.GetComponent<TextMeshProUGUI>();

        if (controller == null)
        {
            Debug.LogError("PlayerController not found. Make sure it's attached to the player GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (controller != null)
        {
            tmpText.text = "HighScore: " + Mathf.Round(highScore);

            if (controller.GetPlayerScore() > highScore)
            {
                highScore = controller.GetPlayerScore();
            }
        }
    }
}
