using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    // Scene camera
    public GameObject cam;
    // Parallax effect factor
    public float parallaxEffect;

    // Parallax control variables
    private float length, startpos;

    // Use this for initialization
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // FixedUpdate is called every fixed frame-rate frame
    void FixedUpdate()
    {
        // Fix movement
        float fix = (cam.transform.position.x * (1 - parallaxEffect));
        // Get moved distance
        float distance = (cam.transform.position.x * parallaxEffect);
        // Move images (perform parallax)
        Vector3 pos = transform.position;
        transform.position = new Vector3(startpos + distance, pos.y, pos.z);
        // Fix the images position
        if (fix > startpos + length)
        {
            startpos += length;
        }
        else if (fix < startpos - length)
        {
            startpos -= length;
        }
    }
}
