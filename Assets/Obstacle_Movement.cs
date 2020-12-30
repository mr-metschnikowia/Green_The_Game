using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Movement : MonoBehaviour
{
 
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called during initialisation


    // Update is called once per frame
    void FixedUpdate()
    {
        float obstacle_speed = -10f - Time.timeSinceLevelLoad / 2f;

        rb.velocity = new Vector3(0f, 0f, obstacle_speed);
        // Obstacle movement
        // Velocity is proportional to game time

    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    // Destroys any game object once they are out of sight
}
