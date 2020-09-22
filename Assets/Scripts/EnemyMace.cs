using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMace : MonoBehaviour {

  private static float ERROR = 0.01f;

  public float startvpos, endvpos;
  public bool falling;
  public float velocity;

  void FixedUpdate() {
    Vector3 pos = gameObject.transform.position;
    if (!falling && pos.y < endvpos) {
      pos.y += velocity;
    } else {
      pos.y -= velocity;
    }
    //
    if (pos.y < startvpos + ERROR) {
      falling = false;
    } else if (pos.y > endvpos - ERROR) {
      falling = true;
    }
    gameObject.transform.position = pos;
  }
}
