using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  //
  public float moveSpeed = 5f;

  //
  bool jump = false;

  void Update() {
    //
    Jump();
    // Get player's horizontal move
    Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
    transform.position += movement * Time.deltaTime * moveSpeed;
  }

  void Jump() {
    if (Input.GetButtonDown("Jump")) {
      GameObject sprite = gameObject.transform.GetChild(0).gameObject;
      Rigidbody2D body = sprite.GetComponent<Rigidbody2D>();
      body.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
    }
  }
}
