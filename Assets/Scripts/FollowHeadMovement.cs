using UnityEngine;

public class FollowHeadMovement : MonoBehaviour
{
    public Transform targetToFollow;


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.eulerAngles = new Vector3(0f, targetToFollow.eulerAngles.y, 0f);
    }
}
