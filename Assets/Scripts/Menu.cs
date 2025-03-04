using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public void Graj()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void LevelsToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void level1()
    {
        SceneManager.LoadSceneAsync(2);
        Time.timeScale = 1;
    }
    public void level2()
    {
        SceneManager.LoadSceneAsync(3);
        Time.timeScale = 1;
    }

    public void level3()
    {
        SceneManager.LoadSceneAsync(4);
        Time.timeScale = 1;
    }
    public void level4()
    {
        SceneManager.LoadSceneAsync(5);
        Time.timeScale = 1;
    }

    public void level5()
    {
        SceneManager.LoadSceneAsync(6);
        Time.timeScale = 1;
    }
    public void level6()
    {
        SceneManager.LoadSceneAsync(7);
        Time.timeScale = 1;
    }
    
}
