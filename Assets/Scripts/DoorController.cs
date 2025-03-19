using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform player; // Riferimento al Player
    public float detectionRadius = 3f; // Distanza per attivare la porta
    public float openAngle = 90f; // Angolo di apertura della porta
    public float openSpeed = 2f; // Velocità di apertura

    public Animator doorAnimator;

    private bool isOpen = false;

    void Start()
    {

    }

    void OpenDoor()
    {
        isOpen = true;
        doorAnimator.SetBool("OpenDoor", true);
        //StopAllCoroutines();
        //StartCoroutine(RotateDoor(openRotation));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            OpenDoor();
        }
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
