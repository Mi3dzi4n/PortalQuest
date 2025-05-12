using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject GM;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.CompareTag("TeleportTrigger"))
        {
            Debug.Log("TeleportTrigger collision!");
            if (GM != null)
            {
                GM.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                Debug.LogError("GM is not assigned!");
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}