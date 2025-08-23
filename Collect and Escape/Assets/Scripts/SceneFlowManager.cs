using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFlowManager : MonoBehaviour
{
    public static float LastRunTime;

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit pressed (works in build, not in editor)");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadResults()
    {
        SceneManager.LoadScene("Results");
    }

    public void Retry()
    {
        SceneManager.LoadScene("Game");
    }
}
