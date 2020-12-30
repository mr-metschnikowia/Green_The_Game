using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Start_Game : MonoBehaviour
{
    public GameObject[] StartMenuFeatures;

    public GameObject[] SettingsMenuFeatures;

    // Constructing list using Unity UI

   public void Start_Game_function ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    // Switches to game scene

    public void ToSettingsMenu ()
    {
        foreach (GameObject Feature in StartMenuFeatures)
        {
            Feature.SetActive(false);
        }

        foreach (GameObject Feature in SettingsMenuFeatures)
        {
            Feature.SetActive(true);
        }
    }
    // Switches to settings menu by deactiviting main menu features and activating settings menu features

    public void BackToMainMenu()
    {
        foreach (GameObject Feature in SettingsMenuFeatures)
        {
            Feature.SetActive(false);
        }

        foreach (GameObject Feature in StartMenuFeatures)
        {
            Feature.SetActive(true);
        }
    }
    // Switches to settings menu by deactiviting settings menu features and activating main menu features

    public void ResetHighScore ()
    {
        PlayerPrefs.SetInt("HighScore", 0);
    }
    // Function resets the high score stored in PlayerPrefs
}
