using UnityEngine;

// Controls player movement and rotation.
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; // Set player's movement speed.
    public Transform eyesReference;

    private Rigidbody rb; // Reference to player's Rigidbody.

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Access player's Rigidbody.
    }

    // Update is called once per frame
    void Update()
    {

    }




    public void MoveMainPlayerForward()
    {
        Vector3 movement = eyesReference.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
        Debug.Log("Moving forward");
    }

    public void MoveMainPlayerBackward()
    {
        Vector3 movement = -eyesReference.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
        Debug.Log("Moving backward");
    }

    public void MoveMainPlayerRight()
    {
        Vector3 movement = eyesReference.right * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
        Debug.Log("Moving right");
    }

     public void MoveMainPlayerLeft()
    {
        Vector3 movement = -eyesReference.right * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
        Debug.Log("Moving left");
    }

    public void StopPlayer()
    {
        rb.linearVelocity = Vector3.zero;
    }
}