using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private void OnMouseDown()
    {
        // This method will be executed when the sprite shape is clicked
        SceneManager.LoadScene("GameScene");
        // Add your custom logic here
    }
}
