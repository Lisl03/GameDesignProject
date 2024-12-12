using UnityEngine;
using UnityEngine.SceneManagement;  // Dieser Namespace ist notwendig für das Laden von Szenen

public class TitleScreenController : MonoBehaviour
{
    public Animator backgroundAnimator;  // Der Animator für die Hintergrundanimation
    public string sceneToLoad = "Room1";  // Die Szene, die geladen wird

    // Diese Funktion wird aufgerufen, wenn der "Play"-Button gedrückt wird
    public void OnPlayButtonPressed()
    {
        Debug.Log("Play-Button wurde gedrückt!");
        // Startet die Einschlaf-Animation
        backgroundAnimator.SetTrigger("FallAsleep");

        // Setze einen Timer, um nach der Einschlaf-Animation die Szene zu wechseln
        Invoke("LoadGameScene", 3f);  // 3 Sekunden Verzögerung (je nach Länge der Animation)
    }

    // Diese Funktion lädt die neue Szene
    private void LoadGameScene()
    {
        SceneManager.LoadScene(sceneToLoad);  // Lädt die angegebene Szene
    }
}
