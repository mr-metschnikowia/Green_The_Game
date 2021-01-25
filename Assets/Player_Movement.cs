using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    public Transform player;

    float SPEED = 0.15f;

    bool moving = false;

    // defining core variables

    float track_1 = -2.35f;

    float track_2 = -0.15932f;

    float track_3 = 2.35f;

    // defining tracks 

    float target_x = -0.15932f;

    // defining target track

    void Move(ref bool moving, float target_x, float SPEED)
    {
        Vector3 target_track = new Vector3(target_x, player.position.y, player.position.z);

        if (player.position == target_track)
        {
            moving = false;
        }
        else
        {
            player.position = Vector3.Lerp(player.position, target_track, SPEED);
        }
    }

    // method moves player base on input variables and detects when destination has been reached

    void Update()
    {
        if (player.position.y > 0)
        {
            // ensures player is in play area 

            if (Input.touchCount > 0)
            {
                // detects touches

                Touch touch = Input.GetTouch(0);

                // first touch is tracked

                if (touch.phase == TouchPhase.Ended)
                {
                    // condition satisifed when finger is remove from screen 

                    moving = true;

                    Vector3 TouchPosition = touch.position;

                    TouchPosition.z = 10;

                    Vector3 ConvertedTouchPosition = Camera.main.ScreenToWorldPoint(TouchPosition);

                    float PlayerX = player.position.x;

                    float TouchX = ConvertedTouchPosition.x;

                    // position of swipe end recorded

                    if (target_x == track_2)
                    {
                        if (TouchX > PlayerX)
                        {
                            target_x = track_3;
                        }
                        else
                        {
                            target_x = track_1;
                        }
                    }
                    else if (target_x == track_3)
                    {
                        if (TouchX < PlayerX)
                        {
                            target_x = track_2;
                        }
                    }
                    else
                    {
                        if (TouchX > PlayerX)
                        {
                            target_x = track_2;
                        }
                    }

                    // target lane is identified based on relation of swipe end coordinates to player's current position 

                }
            }

            if (moving == true)
            {
                Move(ref moving, target_x, SPEED);
            }

            // player is incrementaly moved to target until destination is reached

            // Touchscreen movement

            // if (Input.GetKey("a"))
            // {
            // player.position = Vector3.Lerp(player.position, track_1, SPEED);
            // }
            // else if (Input.GetKey("s"))
            // {
            // player.position = Vector3.Lerp(player.position, track_2, SPEED);
            // }
            // else if (Input.GetKey("d"))
            // {
            // player.position = Vector3.Lerp(player.position, track_3, SPEED);
            // }
            // Keyboard movement
        }

        if (player.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
        // If player falls off platform EndGame function from GameManager script is activated
    }
}
