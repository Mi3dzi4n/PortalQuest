using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public Transform player; // Referencja do gracza
    public Vector3 offset; // Mo¿esz dodaæ przesuniêcie t³a wzglêdem gracza

    void Update()
    {
        // Synchronizuj pozycjê t³a z graczem
        transform.position = player.position + offset;
    }
}