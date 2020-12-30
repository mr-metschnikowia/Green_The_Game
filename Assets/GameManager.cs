using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    float restart_delay = 2f;

    bool game_has_ended = false;

    public GameObject Game_Over_UI;

    public GameObject ScoreText;

    public GameObject HighScoreText;

    public void EndGame ()
    {
        if (game_has_ended == false)
        {
            game_has_ended = true;

            ScoreText.SetActive(false);

            HighScoreText.SetActive(false);

            Invoke("Game_Over", restart_delay);
        }

    }
    // When invoked, game_has_ended switches to true and the game is restarted. Prevents game from restarting several times during Update ().

    void Game_Over ()
    {
        Game_Over_UI.SetActive(true);
    }
    // Function activates end game UI
}
