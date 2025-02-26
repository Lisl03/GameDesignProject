using UnityEngine;

public class PlayerMovementSound : MonoBehaviour
{
    public AudioSource movementAudioSource; // Referenz zur AudioSource
    public float movementThreshold = 0.1f; // Schwellenwert für Bewegungsgeschwindigkeit

    private Rigidbody2D rb; // Referenz zum Rigidbody2D des Spielers

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (movementAudioSource == null)
        {
            Debug.LogError("Movement AudioSource ist nicht zugewiesen!");
        }

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D ist nicht zugewiesen!");
        }
    }

    void Update()
    {
        float playerSpeed = rb != null ? rb.linearVelocity.magnitude : 0f;
        Debug.Log("Player Velocity: " + playerSpeed);

        if (playerSpeed > movementThreshold)
        {
            if (!movementAudioSource.isPlaying)
            {
                Debug.Log("Spieler bewegt sich: Audio wird abgespielt.");
                movementAudioSource.Play();
            }
        }
        else
        {
            if (movementAudioSource.isPlaying)
            {
                Debug.Log("Spieler steht still: Audio wird pausiert.");
                movementAudioSource.Pause();
            }
        }
    }
}
