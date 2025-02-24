using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public RoomController[] rooms;  // Array, um alle Raum-Controller zu speichern

    void Start()
    {
        // Alle Räume initialisieren
        rooms = FindObjectsOfType<RoomController>();
    }

    void Update()
    {
        // Überprüfen, ob alle Räume korrekt platziert wurden
        if (AreAllRoomsCorrectlyPlaced())
        {
            // Wenn ja, lade die nächste Szene (ersetze "NextScene" mit deinem Szenennamen)
            SceneManager.LoadScene("Puppenhausfertig");  // Beispiel: "NextScene" sollte der Name deiner Zielszene sein
        }
    }

    // Überprüfe, ob alle Räume korrekt platziert sind
    bool AreAllRoomsCorrectlyPlaced()
    {
        foreach (RoomController room in rooms)
        {
            if (!room.IsPlacedCorrectly)
            {
                return false;  // Ein Raum ist nicht korrekt platziert, also gebe "false" zurück
            }
        }

        return true;  // Alle Räume sind korrekt platziert
    }
}
