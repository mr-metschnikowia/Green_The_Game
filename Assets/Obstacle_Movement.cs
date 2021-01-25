using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Movement : MonoBehaviour
{
 
    private Rigidbody rb;

    private Transform obstacle;

    // Create private transform variable 

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        obstacle = GetComponent<Transform>();

        // Get transform of gameobject to which this script is attached
    }
    // Start is called during initialisation


    // Update is called once per frame
    void FixedUpdate()
    {
        float obstacle_speed = -10f - Time.timeSinceLevelLoad / 2f;

        rb.velocity = new Vector3(0f, 0f, obstacle_speed);
        // Obstacle movement
        // Velocity is proportional to game time

        CullObstacles();
    }

    // void OnBecameInvisible()
    // {
        // Destroy(gameObject);
    // }
    // Destroys any game object once they are out of sight

    void CullObstacles ()
    {
        if (obstacle.position.z < -101f)
        {
            Destroy(gameObject);
        }
    }
    // destriy game object if it passes certain point 
}
