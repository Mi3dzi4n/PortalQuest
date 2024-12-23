using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f;                 // Pr�dko�� poruszania si� przeciwnika
    public float leftRange = 5f;            // Zasi�g patrolowania w lewo od �rodka
    public float rightRange = 5f;           // Zasi�g patrolowania w prawo od �rodka
    public float pauseDuration = 2f;        // Czas zatrzymania na �rodku po dw�ch przej�ciach

    private Vector2 centerPoint;            // Punkt �rodkowy patrolu
    private bool movingRight = true;        // Czy przeciwnik porusza si� w prawo
    private int patrolCount = 0;            // Licznik przej�� w jedn� stron�
    private bool isPaused = false;          // Czy przeciwnik jest aktualnie zatrzymany

    void Start()
    {
        // Ustaw punkt �rodkowy patrolu jako pocz�tkow� pozycj� przeciwnika
        centerPoint = transform.position;
    }

    void Update()
    {
        if (!isPaused)
        {
            Patrol();
        }
    }

    void Patrol()
    {
        // Poruszaj si� w lewo lub w prawo w zale�no�ci od kierunku
        float step = speed * Time.deltaTime * (movingRight ? 1 : -1);
        transform.position += new Vector3(step, 0, 0);

        // Sprawd�, czy przeciwnik osi�gn�� granic� patrolowania
        if (movingRight && transform.position.x >= centerPoint.x + rightRange)
        {
            movingRight = false; // Zmie� kierunek na lewo
            OnPatrolEnd();
        }
        else if (!movingRight && transform.position.x <= centerPoint.x - leftRange)
        {
            movingRight = true; // Zmie� kierunek na prawo
            OnPatrolEnd();
        }
    }

    void OnPatrolEnd()
    {
        patrolCount++; // Zwi�ksz licznik przej��

        // Je�li licznik osi�gn�� 2 przej�cia, zatrzymaj si� na �rodku
        if (patrolCount >= 2)
        {
            patrolCount = 0; // Zresetuj licznik
            StartCoroutine(PauseAtCenter());
        }
    }

    IEnumerator PauseAtCenter()
    {
        isPaused = true;

        // Przenie� przeciwnika na �rodek
        transform.position = new Vector3(centerPoint.x, transform.position.y, transform.position.z);
        yield return new WaitForSeconds(pauseDuration); // Zatrzymaj si� na okre�lony czas
        isPaused = false;
    }

    private void OnDrawGizmosSelected()
    {
        // Rysowanie zakresu patrolowania w edytorze Unity
        Gizmos.color = Color.yellow;
        if (Application.isPlaying)
        {
            Gizmos.DrawLine(new Vector3(centerPoint.x - leftRange, transform.position.y, transform.position.z),
                            new Vector3(centerPoint.x + rightRange, transform.position.y, transform.position.z));
        }
        else
        {
            Gizmos.DrawLine(new Vector3(transform.position.x - leftRange, transform.position.y, transform.position.z),
                            new Vector3(transform.position.x + rightRange, transform.position.y, transform.position.z));
        }
    }
}
