using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCObject : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("NPCObject Script added!");
    }

    //private void Update()
    //{
    //    Debug.Log("NPCObject Script loaded!");
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("!!!!!!!!     PLAYER CONTACT      !!!!!!!");
            SceneManager.LoadScene("GameOverMenu");
        }
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("!!!!!!!!     PLAYER CONTACT      !!!!!!!");
            SceneManager.LoadScene("GameOverMenu");
        }
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("!!!!!!!!     PLAYER CONTACT      !!!!!!!");
            SceneManager.LoadScene("GameOverMenu");
        }

        if (collision.gameObject.name == "Destroyer")
        {
            Destroy(gameObject);
        }
    }



}
