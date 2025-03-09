using UnityEngine;

public class PlayerSpawnManager : MonoBehaviour
{
    void Start()
    {
        // Überprüfen, ob gespeicherte Position existiert
        if (PlayerPrefs.HasKey("PlayerPosX") && PlayerPrefs.HasKey("PlayerPosY") && PlayerPrefs.HasKey("PlayerPosZ"))
        {
            // Position aus PlayerPrefs laden
            float x = PlayerPrefs.GetFloat("PlayerPosX");
            float y = PlayerPrefs.GetFloat("PlayerPosY");
            float z = PlayerPrefs.GetFloat("PlayerPosZ");

            // Spieler an gespeicherte Position setzen
            transform.position = new Vector3(x, y, z);

            Debug.Log($"Spieler wurde an die gespeicherte Position gesetzt: {x}, {y}, {z}");
        }
        else
        {
            Debug.LogWarning("Keine gespeicherte Position gefunden! Spieler bleibt auf Standard-Spawn.");
        }
    }
}
