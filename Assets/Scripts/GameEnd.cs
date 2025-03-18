using UnityEngine;
using System.Collections.Generic;
using TMPro; // Importa TextMeshPro per la UI

public class EndGame : MonoBehaviour
{
    public Transform[] objects; // Array di oggetti da controllare
    public float areaRadius = 2f; // Raggio dell'area target
    public Material individualMaterial; // Materiale quando entra nell'area
    public Material exitMaterial; // Materiale quando esce dall'area

    public AudioSource backgroundMusic; // AudioSource per la musica di sottofondo
    public AudioClip finalMusic; // Nuova musica quando tutti sono dentro
    public float delayBeforeMusicChange = 2f; // Ritardo prima di cambiare la musica (in secondi)

    public TextMeshProUGUI endGameText; // Testo per "Esperienza Finita"

    private HashSet<Transform> insideObjects = new HashSet<Transform>(); // Oggetti dentro l'area
    private bool gameEnded = false; // Per evitare più chiamate a Invoke()

    void Start()
    {
        if (endGameText != null)
        {
            endGameText.gameObject.SetActive(false); // Nasconde il messaggio all'inizio
        }
    }

    void Update()
    {
        if (gameEnded) return; // Evita di continuare a controllare dopo la fine del gioco

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
                CancelInvoke(nameof(ChangeMusicAndShowText));
                gameEnded = false;
            }
        }

        // Se tutti gli oggetti sono dentro e il gioco non è ancora finito
        if (insideObjects.Count == objects.Length && !gameEnded)
        {
            Invoke(nameof(ChangeMusicAndShowText), delayBeforeMusicChange); // Aspetta prima di terminare il gioco
            gameEnded = true;
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

    void ChangeMusicAndShowText()
    {
        if (backgroundMusic != null && finalMusic != null)
        {
            backgroundMusic.clip = finalMusic;
            backgroundMusic.Play();
        }

        // Mostra il messaggio "Esperienza Finita"
        if (endGameText != null)
        {
            endGameText.gameObject.SetActive(true);
            endGameText.text = "Esperienza Finita";
        }

        // Ferma il gioco
        Time.timeScale = 0f;
    }
}
