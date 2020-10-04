using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMace : MonoBehaviour
{
    // Define the range of positions where the enemy move
    public float startvpos, endvpos;
    // Define if the enemy start falling or rising
    public bool falling;
    // Define the enemy velocity
    public float velocity;

    // Movement error
    private static float ERROR = 0.01f;

    // FixedUpdate is called every fixed frame-rate frame
    void FixedUpdate()
    {
        // Get enemy position
        Vector3 pos = gameObject.transform.position;
        // Get the movement direction
        if (!falling && pos.y < endvpos)
        {
            pos.y += velocity;
        }
        else
        {
            pos.y -= velocity;
        }
        // Check if the enemy reached the lower bound
        if (pos.y < startvpos + ERROR)
        {
            falling = false;
        }
        // Check if the enemy reached the upper bound
        else if (pos.y > endvpos - ERROR)
        {
            falling = true;
        }
        // Update enemy position
        gameObject.transform.position = pos;
    }
}
