using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
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
    }
    public void level2()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void level3()
    {
        SceneManager.LoadSceneAsync(4);
    }
    public void level4()
    {
        SceneManager.LoadSceneAsync(5);
    }

    public void level5()
    {
        SceneManager.LoadSceneAsync(6);
    }
    public void level6()
    {
        SceneManager.LoadSceneAsync(7);
    }
}
