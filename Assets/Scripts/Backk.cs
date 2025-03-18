using UnityEngine;
using UnityEngine.Events;
using System.Collections;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Backk : MonoBehaviour
{
    public bool IsHovered { get; set; }

    [SerializeField]
    public UnityEvent OnObjectHover;
    public UnityEvent OnObjectUnhover;

    [SerializeField]
    private Material OnHoverActiveMaterial;

    [SerializeField]
    private Material OnHoverInactiveMaterial;

    private MeshRenderer meshRenderer;
    private Vector3 initialPosition;
    private Coroutine resetCoroutine;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        initialPosition = transform.position;
    }

    void Update()
    {
        if (IsHovered)
        {
            meshRenderer.material = OnHoverActiveMaterial;
            OnObjectHover?.Invoke();

            if (resetCoroutine == null)
            {
                resetCoroutine = StartCoroutine(ResetPositionAfterDelay(2f));
            }
        }
        else
        {
            OnObjectUnhover?.Invoke();
            meshRenderer.material = OnHoverInactiveMaterial;

            if (resetCoroutine != null)
            {
                StopCoroutine(resetCoroutine);
                resetCoroutine = null;
            }
        }
    }

    private IEnumerator ResetPositionAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        transform.position = initialPosition;
        resetCoroutine = null;
    }
}
