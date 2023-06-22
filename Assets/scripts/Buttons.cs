using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void LoadMenuButtonClick()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadFirstSceneButtonClick()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadSecondSceneButtonClick()
    {
        SceneManager.LoadScene(2);
    }
    public void ExitButtonClick()
    {
        Application.Quit();
    }
}
