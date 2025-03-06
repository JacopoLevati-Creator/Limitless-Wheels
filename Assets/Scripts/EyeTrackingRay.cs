using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]

public class EyeTrackingRay : MonoBehaviour
{
    [SerializeField]
    private float rayDistance = 1.0f;

    [SerializeField]
    private float rayWidth = 0.01f;

    [SerializeField]
    private LayerMask layersToInclude;

    [SerializeField]
    private Color rayColorDefaultState = Color.yellow;

    [SerializeField]
    private Color rayColorHoverState = Color.red;

    [SerializeField]
    private float moveSpeed = 2.0f; // Velocità di movimento

    private LineRenderer lineRenderer;

    private List<EyeInteractable> eyeInteractables = new List<EyeInteractable>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        SetupRay();
    }


    void SetupRay()
    {

        lineRenderer.useWorldSpace = false;
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = rayWidth;
        lineRenderer.endWidth = rayWidth;
        lineRenderer.startColor = rayColorDefaultState;
        lineRenderer.endColor = rayColorDefaultState;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, new Vector3(transform.position.x, transform.position.y,
            transform.position.z + rayDistance));

    }

 




    void FixedUpdate()
    {
        RaycastHit hit;
        Vector3 rayCastDirection = transform.TransformDirection(Vector3.forward);

        bool hasHit = Physics.Raycast(transform.position, rayCastDirection, out hit, rayDistance, layersToInclude);

        if (hasHit && hit.transform.GetComponent<EyeInteractable>() != null)
        {
            UnSelect();

            lineRenderer.startColor = rayColorHoverState;
            lineRenderer.endColor = rayColorHoverState;

            var eyeInteractable = hit.transform.GetComponent<EyeInteractable>();
            if (!eyeInteractables.Contains(eyeInteractable))
                eyeInteractables.Add(eyeInteractable);

            eyeInteractable.IsHovered = true;

            

            Vector3 directionToTarget = (hit.point - transform.position).normalized;
            //transform.position += directionToTarget * 1.0f;
            //transform.position += directionToTarget * moveSpeed * Time.deltaTime; 
            //transform.position= eyeInteractable.Pos;
              
            // Movimento più fluido verso il punto colpito dal raggio
            
            
        }
        else
        {
            lineRenderer.startColor = rayColorDefaultState;
            lineRenderer.endColor = rayColorDefaultState;
            UnSelect(true);
        }


    }

    void UnSelect(bool clear = false)
    {
        foreach(var interactable in eyeInteractables)
        {
            interactable.IsHovered = false;
        }
        if (clear)
        {
            eyeInteractables.Clear();
        }
    } 
}
