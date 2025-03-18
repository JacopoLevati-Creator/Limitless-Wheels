using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform player; // Riferimento al Player
    public float detectionRadius = 3f; // Distanza per attivare la porta
    public float openAngle = 90f; // Angolo di apertura della porta
    public float openSpeed = 2f; // Velocità di apertura

    private Quaternion closedRotation;
    private Quaternion openRotation;
    private bool isOpen = false;

    void Start()
    {
        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + openAngle, transform.eulerAngles.z);
    }

    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) <= detectionRadius && !isOpen)
        {
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        isOpen = true;
        StopAllCoroutines();
        StartCoroutine(RotateDoor(openRotation));
    }

    IEnumerator RotateDoor(Quaternion targetRotation)
    {
        float elapsedTime = 0f;
        Quaternion startRotation = transform.rotation;

        while (elapsedTime < 1f)
        {
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime);
            elapsedTime += Time.deltaTime * openSpeed;
            yield return null;
        }

        transform.rotation = targetRotation;
    }
}
