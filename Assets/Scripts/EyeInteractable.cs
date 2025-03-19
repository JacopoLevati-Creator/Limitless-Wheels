using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]

public class EyeInteractable : MonoBehaviour
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start() => meshRenderer = GetComponent<MeshRenderer>();

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsHovered)
        {
            meshRenderer.material = OnHoverActiveMaterial;
            //gameObject.transform.position = gameObject.transform.position + (new Vector3(0f,0f,1f) * 0.001f); //Push cubes away when looked at
            OnObjectHover?.Invoke();
        }
        else
        {
            OnObjectUnhover?.Invoke();
            meshRenderer.material = OnHoverInactiveMaterial;
        }
    }
}
