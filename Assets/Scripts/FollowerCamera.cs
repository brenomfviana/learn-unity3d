using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerCamera : MonoBehaviour
{
    // Player to be followed
    public Transform player;
    // Horizontal level's bounds
    public Transform wall1;
    public Transform wall2;
    // Bounds
    public float bottom;
    public float herror;

    // Update is called once per frame
    void Update()
    {
        // Get player position
        Vector2 ppos = player.position;
        // Get current camera position
        Vector3 cpos = transform.position;
        // Calculate camera width and height
        float height = 2f * GetComponent<Camera>().orthographicSize;
        float width = height * GetComponent<Camera>().aspect;
        Vector2 offset = new Vector2(width / 2, height / 2);
        // Calculate camera position
        float xpos = ppos.x;
        float ypos = ppos.y;
        xpos = Mathf.Max(xpos, wall1.position.x + offset.x + herror);
        xpos = Mathf.Min(xpos, wall2.position.x - offset.x - herror);
        ypos = Mathf.Max(ypos, bottom);
        // Update camera position
        transform.position = new Vector3(xpos, ypos, cpos.z);
    }
}
