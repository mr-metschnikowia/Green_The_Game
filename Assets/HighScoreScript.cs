using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour
{
    public Text highscoretext;

    // Start is called before the first frame update
    void Start()
    {
        highscoretext.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    // Draws high score from PlayerPrefs to display in game screen
}
