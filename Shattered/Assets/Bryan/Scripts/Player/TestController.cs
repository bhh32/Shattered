using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    [Header("Player Components")]
    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer renderer;
    [SerializeField] LayerMask groundLayer;

    [Header("Player Stats")]
    
    // Bool variables
    bool jump;
    bool isJetpacking = false;
    [SerializeField] bool isSprinting = false;
    [SerializeField] bool isGrounded = true;

    // Float variables
    float hor;
    [SerializeField] float walkSpeed;
    [SerializeField] float sprintSpeed;
    [SerializeField] float maxSprintAccel;
    [SerializeField] float maxWalkAccel;
    [SerializeField] float jumpForce;    
    [SerializeField] float groundRayLength;    
    
    void Update()
    {
        // Update key presses
        hor = Input.GetAxis("Horizontal");
        jump = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        isJetpacking = Input.GetKey(KeyCode.Space);
        isSprinting = Input.GetKey(KeyCode.LeftShift);

        // Update movement
        Movement();
    }

    void FixedUpdate()
    {
        // Set the origin of the raycast position
        Vector2 origin = new Vector2(transform.position.x, transform.position.y - (transform.position.y / 2f));

        // Set the hit position of the raycast
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, groundRayLength, groundLayer);

        // If the raycast hits the ground layer the player is grounded
        if (hit.collider != null)
            isGrounded = true;
        // Otherwise it's not
        else
            isGrounded = false;
    }

    void Movement()
    {
        if (!isGrounded && isSprinting)
            isSprinting = false;

        // Check if sprinting (can only sprint on the ground) and adjust the sprint as appropriate
        if (!isSprinting)
            rb.AddRelativeForce(new Vector2(hor * walkSpeed, 0f), ForceMode2D.Force);
        else if (isSprinting && isGrounded)
            rb.AddRelativeForce(new Vector2(hor * sprintSpeed, 0f), ForceMode2D.Force);

        // Flip the sprite when appropriate
        if (hor > 0f)
            renderer.flipX = false;
        else if (hor < 0f)
            renderer.flipX = true;

        // Check if the player is running or sprinting and adjust the max acceleration accordingly
        if (rb.velocity.x > maxWalkAccel && !isSprinting)
            rb.velocity = new Vector2(maxWalkAccel, rb.velocity.y);
        else if (rb.velocity.x < -maxWalkAccel && !isSprinting)
            rb.velocity = new Vector2(-maxWalkAccel, rb.velocity.y);
        else if (rb.velocity.x > maxSprintAccel && isSprinting && isGrounded)
            rb.velocity = new Vector2(maxSprintAccel, rb.velocity.y);
        else if (rb.velocity.x < -maxSprintAccel && isSprinting && isGrounded)
            rb.velocity = new Vector2(-maxSprintAccel, rb.velocity.y);

        // Jump only if grounded and not jetpacking
        if (jump && isGrounded && !isJetpacking)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
}
