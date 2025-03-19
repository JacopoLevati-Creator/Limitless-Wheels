using UnityEngine;
using System.Collections.Generic;

public class EndGame : MonoBehaviour
{
    public Transform[] objects; // Array di oggetti da controllare
    public float areaRadius = 2f; // Raggio dell'area target
    public Material defaultMaterial; // Materiale iniziale
    public Material individualMaterial; // Materiale quando entra nell'area
    public Material exitMaterial; // Materiale quando esce dall'area

    public Transform finalObject; // Oggetto specifico che cambierà materiale alla fine
    public Material finalObjectMaterial; // Nuovo materiale per l'oggetto finale

    public AudioSource backgroundMusic; // AudioSource per la musica di sottofondo
    public AudioClip finalMusic; // Nuova musica quando tutti sono dentro
    public float delayBeforeMusicChange = 2f; // Ritardo prima di cambiare la musica (in secondi)

    private HashSet<Transform> insideObjects = new HashSet<Transform>(); // Oggetti dentro l'area
    private bool musicChangeScheduled = false; // Per evitare più chiamate a Invoke()

    void Start()
    {
        // Inizializza tutti gli oggetti con il materiale di default
        foreach (Transform obj in objects)
        {
            ChangeMaterial(obj, defaultMaterial);
        }
    }

    void Update()
    {
        Vector3 areaCenter = transform.position; // Usa la posizione dell'oggetto che ha questo script

        foreach (Transform obj in objects)
        {
            float distance = Vector3.Distance(obj.position, areaCenter);
            bool isInside = distance <= areaRadius;

            if (isInside && !insideObjects.Contains(obj))
            {
                // Se entra nell'area, cambia materiale e aggiungilo alla lista
                ChangeMaterial(obj, individualMaterial);
                insideObjects.Add(obj);
            }
            else if (!isInside && insideObjects.Contains(obj))
            {
                // Se esce dall'area, cambia materiale e rimuovilo dalla lista
                ChangeMaterial(obj, exitMaterial);
                insideObjects.Remove(obj);

                // Se un oggetto esce mentre il cambio musica è programmato, annulliamo l'Invoke
                CancelInvoke(nameof(ChangeMusicAndFinalObject));
                musicChangeScheduled = false;
            }
        }

        // Se tutti gli oggetti sono dentro e la musica non è ancora stata cambiata
        if (insideObjects.Count == objects.Length && !musicChangeScheduled)
        {
            // Cambia il materiale dell'oggetto specificato
            if (finalObject != null && finalObjectMaterial != null)
            {
                ChangeMaterial(finalObject, finalObjectMaterial);
            }

            Invoke(nameof(ChangeMusicAndFinalObject), delayBeforeMusicChange); // Aspetta prima di cambiare
            musicChangeScheduled = true;
        }
    }

    void ChangeMaterial(Transform obj, Material material)
    {
        Renderer objRenderer = obj.GetComponent<Renderer>();
        if (objRenderer != null && material != null)
        {
            objRenderer.material = material;
        }
    }

    void ChangeMusicAndFinalObject()
    {
        // Cambia la musica
        if (backgroundMusic != null && finalMusic != null)
        {
            backgroundMusic.clip = finalMusic;
            backgroundMusic.Play();
        }

        
    }
}
