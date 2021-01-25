using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Touchscreen movement

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

    private float GlobalStartTouchX;

    // global x value of touch start

    private Vector3 GlobalEndTouch;

    // global value of touch end

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

                if (touch.phase == TouchPhase.Began)
                {
                    GlobalStartTouchX = touch.position.x;
                }

                // Get unconverted x value of touch start

                if (touch.phase == TouchPhase.Ended)
                {
                    // condition satisifed when finger is removed from screen  - movement can only occur after this point 

                    Vector3 EndTouch = touch.position;

                    EndTouch.z = 10;

                    GlobalEndTouch = EndTouch;

                    // grab unconverted position of touch end

                    float EndTouchX = GlobalEndTouch.x;

                    // grab unconverted x value of end touch

                    if (CheckSwipe(EndTouchX, GlobalStartTouchX) == true)
                    // Check if swipe is valid 
                    {
                        moving = true;

                        Vector3 ConvertedTouchPosition = Camera.main.ScreenToWorldPoint(GlobalEndTouch);

                        float PlayerX = player.position.x;

                        float TouchX = ConvertedTouchPosition.x;

                        // position of swipe end converted 

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
                // Get vector 3 unconverted position of touch stop

            }

            if (moving == true)
            {
                Move(ref moving, target_x, SPEED);
            }

            // player is incrementaly moved to target until destination is reached
        }
        else if (player.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        // If player falls off platform EndGame function from GameManager script is activated
    }

    private bool CheckSwipe(float FinalX, float StartX)
    {
        if (Math.Abs(FinalX - StartX) > 100)
        {
            return true;
        }

        return false;
    }

    // Checks if swipe length exceeds threshold
}
