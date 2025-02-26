using UnityEngine;
using UnityEngine.SceneManagement;

public class Colliderscenechanger : MonoBehaviour
{
    public string sceneToLoad; // Name der Szene, die geladen werden soll

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Überprüft, ob der Spieler den Bereich betritt
        {
            SceneManager.LoadScene(sceneToLoad); // Lädt die angegebene Szene
        }
    }
}
