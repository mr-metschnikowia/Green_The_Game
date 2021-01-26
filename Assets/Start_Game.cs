using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Start_Game : MonoBehaviour
{
   public GameObject[] StartMenuFeatures;

   public GameObject[] SettingsMenuFeatures;

   public GameObject[] InstructionsMenuFeatures;

   // Constructing list using Unity UI

   public GameObject DummyPrefab;

   // publicly creating prefab gameobject

   public Transform player;

    // player GameObject assigned value of player avatar

    Vector3 InstructionsPlayerLocation = new Vector3(0f, 1f, -95.86f);

    Vector3 MainPlayerLocation = new Vector3(0f, 1f, -98.29f);

    // Defining possible locations of player avatar across menus

   void ChangeMenu (GameObject[] ToDestroy, GameObject[] ToCreate)
   {
       foreach(GameObject Feature in ToDestroy)
       {
           Feature.SetActive(false);
       }

       foreach(GameObject Feature in ToCreate)
       {
            Feature.SetActive(true);
       }
    }
    // Function deactivates UI features from ToDestroy GameObject list and activates features from ToCreat GameObject list


   public void Start_Game_function ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    // Switches to game scene

    public void ToSettingsMenu ()
    {
        ChangeMenu(StartMenuFeatures, SettingsMenuFeatures);
    }
    // Switches to settings menu by deactiviting main menu features and activating settings menu features

    public void BackToMainMenu()
    {
        ChangeMenu(SettingsMenuFeatures, StartMenuFeatures);

        ChangeMenu(InstructionsMenuFeatures, StartMenuFeatures);

        // Switches to main menu by deactiviting settings + instructions menu features and activating main menu features

        player.position = MainPlayerLocation;

        // player is moved to appropriate position

        try
        {
            GameObject InstructionObstacle;

            // Creating a GameObject

            InstructionObstacle = GameObject.Find("DummyPrefab(Clone)");

            // Spawned prefab assinged to gameobject

            InstructionObstacle.SetActive(false);

            // deactivating spawned prefab
        }
        catch
        {

        }
    }

    public void ResetHighScore ()
    {
        PlayerPrefs.SetInt("HighScore", 0);
    }
    // Function resets the high score stored in PlayerPrefs

    public void ToInstructionsMenu()
    {
        Vector3 SpawnPoint = new Vector3(0f, 0.77f, -89.81021f);

        Instantiate(DummyPrefab, SpawnPoint, Quaternion.identity);

        // Spawning DummyPrefab prefab at SpawnPoint

        ChangeMenu(StartMenuFeatures, InstructionsMenuFeatures);

        player.position = InstructionsPlayerLocation;

        // player is moved to appropriate location
    }

    // To instructions menu

    public void ShowLeaderboard()
    {
        Social.ShowLeaderboardUI();
    }

    // Brings up GPGS leaderboard UI
}
