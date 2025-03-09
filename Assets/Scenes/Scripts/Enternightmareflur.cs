using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterNightmareFlur : MonoBehaviour
{
    public Transform player; // Referenz auf den Spieler
    public Transform targetObject; // Das Objekt, das der Spieler erreichen muss
    public float interactionRange = 3f; // Die Reichweite, in der der Spieler das Objekt erreichen muss

    void Update()
    {
        // Berechne den Abstand zwischen dem Spieler und dem Zielobjekt
        float distanceToTarget = Vector3.Distance(player.position, targetObject.position);

        // Überprüfen, ob der Spieler in der Nähe des Zielobjekts ist und die "Q"-Taste drückt
        if (distanceToTarget <= interactionRange && Input.GetKeyDown(KeyCode.Q))
        {
            // Lade die "Menu"-Szene
            SceneManager.LoadScene("FlurNightmare");
        }
    }
}
