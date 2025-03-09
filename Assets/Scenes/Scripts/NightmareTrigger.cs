using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupItem : MonoBehaviour
{
    public string roomAnimationTrigger = "TransformRoom"; // Trigger-Name für die Raum-Animation
    public string characterAnimationTrigger = "TransformCharacter"; // Trigger-Name für die Charakter-Animation
    public Animator roomAnimator; // Animator für die Raum-Animation
    public Animator characterAnimator; // Animator für die Charakter-Animation
    public GameObject animationObject; // Das Objekt für die Raumveränderung
    private bool isPlayerInRange = false; // Prüft, ob der Spieler in Reichweite ist
    private string nextSceneName = "Nightmare1"; // Name der nächsten Szene

    private void Start()
    {
        // Stelle sicher, dass das Animationsobjekt und der Room-Animator unsichtbar sind
        if (animationObject != null)
        {
            animationObject.SetActive(false);
        }

        if (roomAnimator != null)
        {
            roomAnimator.gameObject.SetActive(false); // Room-Animator unsichtbar machen
        }
    }

    private void Update()
    {
        // Wenn der Spieler in Reichweite ist und 'Q' drückt
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Q))
        {
            TriggerAnimations(); // Animationen starten
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Prüfen, ob der Spieler den Trigger betritt
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true; // Spieler ist in Reichweite
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Prüfen, ob der Spieler den Trigger verlässt
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false; // Spieler ist nicht mehr in Reichweite
        }
    }

    private void TriggerAnimations()
    {
        // Speichern der Position des Charakters vor dem Szenenwechsel
        Vector3 playerPosition = GameObject.FindWithTag("Player").transform.position;
        PlayerPrefs.SetFloat("PlayerPosX", playerPosition.x);
        PlayerPrefs.SetFloat("PlayerPosY", playerPosition.y);
        PlayerPrefs.SetFloat("PlayerPosZ", playerPosition.z);

        // Raumanimation sichtbar machen und starten
        if (animationObject != null)
        {
            animationObject.SetActive(true);
        }

        if (roomAnimator != null)
        {
            roomAnimator.gameObject.SetActive(true); // Room-Animator aktivieren
            Debug.Log("Triggering room animation...");
            roomAnimator.SetTrigger(roomAnimationTrigger); // Raumanimation starten
        }
        else
        {
            Debug.LogWarning("Room Animator ist nicht zugewiesen!");
        }

        // Charakteranimation starten
        if (characterAnimator != null)
        {
            characterAnimator.SetTrigger(characterAnimationTrigger);
        }
        else
        {
            Debug.LogWarning("Character Animator ist nicht zugewiesen!");
        }

        // Verzögerten Szenenwechsel starten
        Invoke(nameof(SwitchScene), 3f);
    }

    private void SwitchScene()
    {
        // Szene wechseln
        SceneManager.LoadScene(nextSceneName);
    }

    // Diese Methode wird durch ein Event in der Animation aufgerufen
    public void OnAnimationComplete()
    {
        // Optional: Nach der Animation den Room-Animator wieder deaktivieren
        if (roomAnimator != null)
        {
            roomAnimator.gameObject.SetActive(false);
        }

        // Szene wechseln, nachdem die Animation abgeschlossen ist
        SwitchScene();
    }
}
