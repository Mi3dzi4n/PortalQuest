using UnityEngine;

public class zabijanie : MonoBehaviour
{
    private Vector2 startPosition; 

    void Start()
    {
        startPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TeleportTrigger"))
        {
            transform.position = startPosition;
            Debug.Log("Gracz zosta³ przeteleportowany na start!");
        }
    }

   
}
