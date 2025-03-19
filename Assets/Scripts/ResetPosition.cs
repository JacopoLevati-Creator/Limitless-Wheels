using UnityEngine;
using System.Collections;

public class ResetPosition : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    public float resetThresholdY = 0.5f; // Soglia sull'asse Y
    public float resetDelay = 1f; // Ritardo prima del reset

    private bool isResetting = false; // Per evitare richieste multiple

    void Start()
    {
        // Salva la posizione e la rotazione iniziale dell'oggetto
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void Update()
    {
        // Controlla se l'oggetto ha superato la soglia in Y e non sta già aspettando il reset
        if (transform.position.y <= resetThresholdY && !isResetting)
        {
            StartCoroutine(ResetAfterDelay());
        }
    }

    IEnumerator ResetAfterDelay()
    {
        isResetting = true; // Evita chiamate ripetute
        yield return new WaitForSeconds(resetDelay); // Aspetta il tempo specificato

        // Ripristina posizione e rotazione iniziali
        transform.position = initialPosition;
        transform.rotation = initialRotation;

        isResetting = false; // Permette futuri reset
    }
}
