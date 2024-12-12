using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance; // Singleton-Instanz

    void Awake()
    {
        // Überprüfen, ob bereits ein MusicManager existiert
        if (instance != null)
        {
            Destroy(gameObject); // Falls schon einer existiert, zerstöre das neue Musik-Objekt
        }
        else
        {
            instance = this; // Setze die Instanz
            DontDestroyOnLoad(gameObject); // Verhindere, dass das Musik-Objekt beim Szenenwechsel zerstört wird
        }
    }
}
