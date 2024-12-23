using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f;                 // Prêdkoœæ poruszania siê przeciwnika
    public float leftRange = 5f;            // Zasiêg patrolowania w lewo od œrodka
    public float rightRange = 5f;           // Zasiêg patrolowania w prawo od œrodka
    public float pauseDuration = 2f;        // Czas zatrzymania na œrodku po dwóch przejœciach

    private Vector2 centerPoint;            // Punkt œrodkowy patrolu
    private bool movingRight = true;        // Czy przeciwnik porusza siê w prawo
    private int patrolCount = 0;            // Licznik przejœæ w jedn¹ stronê
    private bool isPaused = false;          // Czy przeciwnik jest aktualnie zatrzymany

    void Start()
    {
        // Ustaw punkt œrodkowy patrolu jako pocz¹tkow¹ pozycjê przeciwnika
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
        // Poruszaj siê w lewo lub w prawo w zale¿noœci od kierunku
        float step = speed * Time.deltaTime * (movingRight ? 1 : -1);
        transform.position += new Vector3(step, 0, 0);

        // SprawdŸ, czy przeciwnik osi¹gn¹³ granicê patrolowania
        if (movingRight && transform.position.x >= centerPoint.x + rightRange)
        {
            movingRight = false; // Zmieñ kierunek na lewo
            OnPatrolEnd();
        }
        else if (!movingRight && transform.position.x <= centerPoint.x - leftRange)
        {
            movingRight = true; // Zmieñ kierunek na prawo
            OnPatrolEnd();
        }
    }

    void OnPatrolEnd()
    {
        patrolCount++; // Zwiêksz licznik przejœæ

        // Jeœli licznik osi¹gn¹³ 2 przejœcia, zatrzymaj siê na œrodku
        if (patrolCount >= 2)
        {
            patrolCount = 0; // Zresetuj licznik
            StartCoroutine(PauseAtCenter());
        }
    }

    IEnumerator PauseAtCenter()
    {
        isPaused = true;

        // Przenieœ przeciwnika na œrodek
        transform.position = new Vector3(centerPoint.x, transform.position.y, transform.position.z);
        yield return new WaitForSeconds(pauseDuration); // Zatrzymaj siê na okreœlony czas
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
