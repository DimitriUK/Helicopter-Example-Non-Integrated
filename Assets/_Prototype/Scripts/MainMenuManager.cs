using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OpenIAPStore()
    {

    }
    public void OpenAchievements()
    {

    }
    public void OpenLeaderboards()
    {

    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
