using UnityEngine;

public class Player : MonoBehaviour, PlayerInterface
{
    // Player public attributes
    public float moveSpeed = 5f;
    public SpriteRenderer sptrndr;
    public Rigidbody2D rbody;
    public Animator animator;
    
    // Player private attributes
    private float hmove = 0;
    private int jumps = 0;

    // Update is called once per frame
    void Update()
    {
        // # Perform animations
        // Player direction
        if (hmove < 0)
        {
            sptrndr.flipX = true;
        }
        else if (hmove > 0)
        {
            sptrndr.flipX = false;
        }
        // Running
        animator.SetFloat("Speed", Mathf.Abs(hmove));
        // Falling
        if (rbody.velocity.y < 0)
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", true);
        }
        // In ground
        if (rbody.velocity.y == 0)
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", false);
            jumps = 0;
        }
    }

    // FixedUpdate is called every fixed frame-rate frame
    void FixedUpdate()
    {
        // Get player's horizontal move
        Vector3 movement = new Vector3(hmove, 0f, 0f);
        transform.position += movement * Time.deltaTime;
    }

    // Perform player movement
    public void Move(float axis)
    {
        hmove = axis * moveSpeed;
    }

    // Perform player jump and double jump
    public void Jump()
    {
        if (jumps < 2)
        {
            // Reset jump
            rbody.velocity = new Vector3(0f, 0f, 0f);
            // Calculate the jump force
            Vector2 jumpForce = new Vector2(0f, 5f);
            if (jumps == 1 && animator.GetBool("IsFalling"))
            {
                jumpForce = new Vector2(0f, 2.5f);
            }
            // Perform the jump
            rbody.AddForce(jumpForce, ForceMode2D.Impulse);
            // Jump counter
            jumps += 1;
            // Start animation
            animator.SetBool("IsJumping", true);
            FindObjectOfType<SoundManager>().Play("Jump");
        }
    }
}
