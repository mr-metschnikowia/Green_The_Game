using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    public Transform player;

    Vector3 track_1 = new Vector3(-2.35f, 1f, -98.16975f);

    Vector3 track_2 = new Vector3(-0.15932f, 1f, -98.16975f);

    Vector3 track_3 = new Vector3(2.35f, 1f, -98.16975f);

    float SPEED = 0.15f;

    Vector3 CurrentLane = new Vector3(-0.15932f, 1f, -98.16975f);

    bool moving = false;

    // defining core variables


    void Move(ref bool moving, Vector3 CurrentLane, float SPEED)
    {
        if (player.position == CurrentLane)
        {
            moving = false;
        }
        else
        {
            player.position = Vector3.Lerp(player.position, CurrentLane, SPEED);
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
                // first touch is tracked

                Touch touch = Input.GetTouch(0);

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

                    if (CurrentLane == track_2)
                    {
                        if (TouchX > PlayerX)
                        {
                            CurrentLane = track_3;
                        }
                        else
                        {
                            CurrentLane = track_1;
                        }
                    }
                    else if (CurrentLane == track_3)
                    {
                        if (TouchX < PlayerX)
                        {
                            CurrentLane = track_2;
                        }
                    }
                    else
                    {
                        if (TouchX > PlayerX)
                        {
                            CurrentLane = track_2;
                        }
                    }

                    // target lane is identified based on relation of swipe end coordinates to player's current position 

                }
            }

            if (moving == true)
            {
                Move(ref moving, CurrentLane, SPEED);
            }

            // player is incrementaly moved to target until destination is reached

            // Touchscreen movement

            if (Input.GetKey("a"))
            {
                player.position = Vector3.Lerp(player.position, track_1, SPEED);
            }
            else if (Input.GetKey("s"))
            {
                player.position = Vector3.Lerp(player.position, track_2, SPEED);
            }
            else if (Input.GetKey("d"))
            {
                player.position = Vector3.Lerp(player.position, track_3, SPEED);
            }
            // Keyboard movement
        }

        if (player.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
       // If player falls off platform EndGame function from GameManager script is activated
    }
}
