using UnityEngine;

public class ChangeMaterialOnArea : MonoBehaviour
{
    public Transform[] objects; // Array di oggetti da controllare
    public Vector3 areaCenter = new Vector3(0, 0, 0); // Centro dell'area target
    public float areaRadius = 2f; // Raggio dell'area target
    public Material newMaterial; // Nuovo materiale da applicare

    private bool materialChanged = false;

    void Update()
    {
        if (!materialChanged && AllObjectsInArea())
        {
            ChangeMaterial();
        }
    }

    bool AllObjectsInArea()
    {
        foreach (Transform obj in objects)
        {
            if (Vector3.Distance(obj.position, areaCenter) > areaRadius)
            {
                return false; // Se almeno un oggetto è fuori dall'area, ritorna false
            }
        }
        return true;
    }

    void ChangeMaterial()
    {
        foreach (Transform obj in objects)
        {
            Renderer objRenderer = obj.GetComponent<Renderer>();
            if (objRenderer != null && newMaterial != null)
            {
                objRenderer.material = newMaterial;
            }
        }
        materialChanged = true; // Evita di cambiare materiale più volte
    }
}
