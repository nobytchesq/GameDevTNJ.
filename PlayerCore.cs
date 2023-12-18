using System.Collections;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Rigidbody2D playerRb;
    public Animator animator;
    public SpriteRenderer spriterender;
    public float jumpforce;
    public LayerMask groundLayer;
    private bool isGrounded;
    public Transform feetPosition;
    public float groundCheckCircle;
    public float jumpTime = 0.35f;
    public float jumpTimeCounter;
    private bool isJumping;

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        playerRb.velocity = new Vector2(movement.x * moveSpeed, playerRb.velocity.y);

        // Animator
        animator.SetFloat("Blend", Mathf.Abs(movement.x));

        // Flipping
        if(movement.x < 0)
        {
            spriterender.flipX = true;
        }
        else if (movement.x > 0)
        {
            spriterender.flipX = false;
        }

        // Check if player is grounded
        isGrounded = Physics2D.CircleCast(feetPosition.position, groundCheckCircle, Vector2.down, groundLayer);

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpforce);
        }

        if (isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                playerRb.velocity = new Vector2(playerRb.velocity.x, jumpforce);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
    }

    void Flip()
    {
        spriterender.flipX = !spriterender.flipX;
    }
}
