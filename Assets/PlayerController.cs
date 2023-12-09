using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isGrounded = false;
    private bool canJump = true; // New variable to track jumping state
    public float jumpForce = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);

        // Allow jumping only when grounded and not already jumping
        if (isGrounded && canJump && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        rb.gravityScale = 2;

        // Set canJump to false to prevent multiple jumps until grounded again
        canJump = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
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
}
