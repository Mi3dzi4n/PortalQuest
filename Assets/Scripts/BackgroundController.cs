using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public Transform player; // Referencja do gracza
    public Vector3 offset; // Mo�esz doda� przesuni�cie t�a wzgl�dem gracza

    void Update()
    {
        // Synchronizuj pozycj� t�a z graczem
        transform.position = player.position + offset;
    }
}