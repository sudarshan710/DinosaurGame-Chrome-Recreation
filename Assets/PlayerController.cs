using Unity;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //private static PlayerController _instance;

    //public static PlayerController Instance
    //{
    //    get
    //    {
    //        if (_instance == null)
    //        {
    //            GameObject playerControllerObject = new GameObject("PlayerController");
    //            _instance = playerControllerObject.AddComponent<PlayerController>();
    //            DontDestroyOnLoad(playerControllerObject);
    //        }
    //        return _instance;
    //    }
    //}

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private bool canJump = true; // New variable to track jumping state
    public float jumpForce = 9f;
    private Vector3 originalScale;

    //private bool isAlive = true;
    private float playerScore;
    private float scoreIncreaseFactor = 4f;

    public TextMeshProUGUI tmpText;

    public float GetPlayerScore()
    {
        return playerScore;
    }



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerScore = 1;
        originalScale = transform.localScale;
        tmpText = GameObject.Find("PlayerScoreUI")?.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        playerScore += scoreIncreaseFactor * Time.deltaTime;
        if (tmpText != null)
        {
            tmpText.text = "PlayerScore: " + Mathf.Round(playerScore);
        }
        else
        {
            Debug.LogError("TextMeshProUGUI not found!");
        }
        Debug.Log("Score : " + playerScore);
        //if (isAlive)
        //{
        //    playerScore += playerScore *  Time.deltaTime;
        //}

        Debug.Log($"isGrounded: {isGrounded}");
        //int groundLayer = LayerMask.NameToLayer("Base");

        Debug.DrawRay(transform.position, Vector2.down * 1.44f, Color.red);

        // Check if the player is grounded
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1.44f, LayerMask.GetMask("Base"));
        //isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 3f);


        // Allow jumping only when grounded and not already jumping
        if (isGrounded && canJump && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            Jump();
        }

        if (isGrounded && canJump && (Input.GetKey(KeyCode.DownArrow)))
        {
            if (transform.localScale.y > (originalScale.y/2))
            {
                Vector3 newScale = transform.localScale;
                newScale.y *= 0.5f;
                transform.localScale = newScale;
                Vector3 newPos = transform.position;
                newPos.y = -2.805f;
                transform.position = newPos;
                //movDown();
            }
        }
        if (isGrounded && canJump && (Input.GetKeyUp(KeyCode.DownArrow)))
        {
            transform.localScale = originalScale;
            Vector3 newPos = transform.position;
            newPos.y = -2.331f;
            transform.position = newPos;
            //movDown();
        }

        if ((transform.position.y > -2.354f))
        {
            movDown();
        }
    }

    private void movDown()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.AddForce(Vector2.down * jumpForce, ForceMode2D.Impulse);
        }
    }
    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        rb.gravityScale = 4;
        isGrounded = false;

        // Set canJump to false to prevent multiple jumps until grounded again
        canJump = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        rb.velocity = Vector2.zero;
        Debug.Log("TRIGGER ENTERED");
        Debug.Log($"Collided with layer: {LayerMask.LayerToName(other.gameObject.layer)}");

        if (other.gameObject.layer == LayerMask.NameToLayer("Base"))
        {
            Debug.Log("CHANGING GRAVITY SCALE.....");
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0f;

            // Allow jumping again when grounded
            canJump = true;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Triangle"))
        {
            Debug.Log("!!!!!!!!     PLAYER CONTACT      !!!!!!!");
            SceneManager.LoadScene("GameOverMenu");
        }
        if (collision.gameObject.name == "Bullet" || collision.gameObject.name == "Triangle")
        {
            Debug.Log("!!!!!!!!     PLAYER CONTACT      !!!!!!!");
            SceneManager.LoadScene("GameOverMenu");
        }
        if (collision.collider.CompareTag("Bullet") || collision.collider.CompareTag("Triangle"))
        {
            Debug.Log("!!!!!!!!     PLAYER CONTACT      !!!!!!!");
            SceneManager.LoadScene("GameOverMenu");
        }
    }
}
