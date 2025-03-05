using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]

public class EyeInteractable : MonoBehaviour
{
   
    public bool IsHovered { get; set; }
    


    [SerializeField]
    private UnityEvent<GameObject> OnObjectHover;

    [SerializeField]
    private Material OnHoverActiveMaterial;

    [SerializeField]
    private Material OnHoverInactiveMaterial;

    public Vector3 posizioneCubo;
    private MeshRenderer meshRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() => meshRenderer = GetComponent<MeshRenderer>();

    // Update is called once per frame
    void Update()
    {
        if (IsHovered)
        {
            meshRenderer.material = OnHoverActiveMaterial;
            OnObjectHover?.Invoke(gameObject);

            posizioneCubo = transform.position;
            transform.position = new Vector3(1, 1, 1); // dove x, y, z sono le nuove coordinate

        }
        else
        {
            meshRenderer.material = OnHoverInactiveMaterial;
        }
    }
}
