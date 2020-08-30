using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  //
  public float moveSpeed = 5f;
  public SpriteRenderer sptrndr;
  public Rigidbody2D rbody;
  public Animator animator;

  // Player horizontal movement
  float hmove = 0;
  int jumps = 0;

  void Update() {
    // Get inputs
    hmove = Input.GetAxis("Horizontal") * moveSpeed;
    // Check if the player pressed the jump button
    if (Input.GetButtonDown("Jump") && (jumps < 2)) {
      // Calculate the jump force
      Vector2 jumpForce = new Vector2(0f, 5f);
      if (jumps == 1) {
        jumpForce = new Vector2(0f, 2.5f);
      }
      // Perform the jump
      rbody.AddForce(jumpForce, ForceMode2D.Impulse);
      // Jump counter
      jumps += 1;
      // Start animation
      animator.SetBool("IsJumping", true);
    }
    // # Animations
    // Player direction
    if (hmove < 0) {
      sptrndr.flipX = true;
    } else if (hmove > 0) {
      sptrndr.flipX = false;
    }
    // Running
    animator.SetFloat("Speed", Mathf.Abs(hmove));
    // Falling
    if (rbody.velocity.y < 0) {
      animator.SetBool("IsJumping", false);
      animator.SetBool("IsFalling", true);
    }
    // Jumping
    if (rbody.velocity.y == 0) {
      animator.SetBool("IsJumping", false);
      animator.SetBool("IsFalling", false);
      jumps = 0;
    }
  }

  void FixedUpdate() {
    // Get player's horizontal move
    Vector3 movement = new Vector3(hmove, 0f, 0f);
    transform.position += movement * Time.deltaTime;
  }
}
