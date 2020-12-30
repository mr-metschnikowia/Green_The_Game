using UnityEngine;
using UnityEngine.SceneManagement;
public class Quit_to_Menu : MonoBehaviour
{

    public void Quit_Game ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    // User is returned to the main menu
    
}
