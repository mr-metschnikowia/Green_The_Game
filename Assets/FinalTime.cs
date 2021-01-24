using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FinalTime : MonoBehaviour
{
    public Text FinalTimeText;

    public GameObject NewHighScoreText;

    // Start is called before the first frame update

    void Start()
    {
        int FinalTimeInt = Mathf.RoundToInt((float)Time.timeSinceLevelLoad) - 2;

        FinalTimeText.text = "Final Time: " + FinalTimeInt.ToString() + " seconds";
        // Final time achieved by player is written to GUI

        if (PlayerPrefs.GetInt("HighScore", 0) < FinalTimeInt)
        {
            PlayerPrefs.SetInt("HighScore", FinalTimeInt);

            Social.ReportScore(PlayerPrefs.GetInt("HighScore", 1), GPGSIds.leaderboard_high_score, null);

            // Sends high score to GPGS leaderboard

            StartCoroutine(FlashText());
        }
        // If player beats old high score, the new high score is stored and a congratulatory message appears (using FlashText coroutine function)    
    }

    IEnumerator FlashText ()
    {
        while (true)
        {
            NewHighScoreText.SetActive(true);

            yield return new WaitForSeconds(0.5f);

            NewHighScoreText.SetActive(false);

            yield return new WaitForSeconds(0.5f);
        }
    }
}   // Coroutine function (function carried out in chunks) facilitates flashing of text
