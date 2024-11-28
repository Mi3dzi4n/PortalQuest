using UnityEngine;

public class zabijanie : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Vector2 startPosition; 

    void Start()
    {
        startPosition = transform.position;
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TeleportTrigger"))
        {
            rb2D.linearVelocity = Vector2.zero;
            transform.position = startPosition;
            Debug.Log("Gracz zosta³ przeteleportowany na start!");
        }
    }

   
}
