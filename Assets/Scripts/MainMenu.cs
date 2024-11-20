using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Load the first level
        SceneManager.LoadScene("Level1");
    }
    
    public void OpenSettings()
    {
        // Implement settings functionality
        Debug.Log("Settings opened.");
    }

    public void OpenCredits ()
    {
        // Implement credits functionality
        Debug.Log("Credits opened.");
    }
    
    public void OpenLeaderboard ()
    {
        // Implement Leaderboard functionality
        Debug.Log("Leaderboard opened.");
    }

    public void ExitGame ()
    {
        // Quit the application
        Application.Quit();
    }
    
    
}
