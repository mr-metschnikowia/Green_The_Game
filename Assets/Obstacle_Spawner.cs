using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Spawner : MonoBehaviour
{
    public Transform[] obstacle_coordinates;
    // List is created in Unity UI of potential spawn coordinates

    public GameObject ObstaclePrefab;

    private float Time_to_spawn = 0f;

    void spawn_objects()
    {
        int random_index = Random.Range(0, obstacle_coordinates.Length);
        // generates a random integer between 0 and length of coordinate list

        for (int i = 0; i < obstacle_coordinates.Length; i++)
        {
            if (i != random_index)
            {
                Instantiate(ObstaclePrefab, obstacle_coordinates[i].position, Quaternion.identity);
            }
        }
        // an obstacle is spawned at each coordinate in list, other than coordinate with index equal to random integer - element of randomness
    }
    // function spawns obstacles

    void Update()
    {
        float raw_spawn_time = 1f - (Time.timeSinceLevelLoad / 100f);
        // spawn timer is proportional to game time

        float Time_in_between_waves = Mathf.Clamp(raw_spawn_time, 0.5f, 1f);
        // Limits value of spawn time >= 0.5

        if (Time.timeSinceLevelLoad >= Time_to_spawn)
        {
            spawn_objects();
            Time_to_spawn = Time.timeSinceLevelLoad + Time_in_between_waves;
        }
        // Spawns obstacle after set time interval (specified by raw_spawn_time)
    }
    // Update is called once per frame
}   
  
