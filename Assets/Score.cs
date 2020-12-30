using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Score : MonoBehaviour
{
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Time: " + Math.Round(Time.timeSinceLevelLoad).ToString();
    }
}   // Time is displayed in UI
