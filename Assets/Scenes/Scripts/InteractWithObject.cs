using UnityEngine;
using UnityEngine.SceneManagement;  // Zum Wechseln der Szene
using UnityEngine.UI;  // Um UI-Elemente wie Text zu verwenden

public class InteractWithObject : MonoBehaviour
{
    public string sceneToLoad;  // Name der Szene, die geladen werden soll
    public float interactDistance = 3f;  // Maximale Entfernung, um zu interagieren
    
    private GameObject player;  // Referenz auf den Spieler
    private bool isPlayerInRange = false;  // Flag, ob der Spieler in Reichweite ist

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");  // Den Spieler suchen (hier wird der Tag "Player" verwendet)
        
    }

    private void Update()
    {
        // Überprüfen, ob der Spieler sich in der Nähe des Objekts befindet und die Taste "Q" gedrückt wurde
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Q))
        {
            // Szene wechseln
            ChangeScene();
        }

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Wenn der Spieler in den Triggerbereich des Objekts eintritt
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;  // Spieler ist in Reichweite
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Wenn der Spieler den Triggerbereich verlässt
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;  // Spieler ist nicht mehr in Reichweite
        }
    }

    private void ChangeScene()
    {
        // Szene wechseln
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);  // Hier wird die Szene geladen
        }
    }
}