using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    int scene;
    private void Start()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.CompareTag("Portal"))
        {
            SceneManager.LoadScene(scene + 1);
            Debug.Log("no");
        }
    }

}