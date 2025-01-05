using UnityEngine;
using UnityEngine.SceneManagement;  // Für den Szenenwechsel

public class MenuController : MonoBehaviour
{
    public Animator animator; // Der Animator des Mädchens
    public string sceneToLoad = "Room1"; // Name der Szene, die nach der Animation geladen wird
    public float animationDuration = 2f; // Dauer der Einschlaf-Animation (in Sekunden)

    // Methode, die durch den Play-Button getriggert wird
    public void OnPlayButtonClicked()
    {
        // Start der Einschlaf-Animation
        animator.SetTrigger("FallAsleep");

        // Nach der Dauer der Einschlaf-Animation die Szene wechseln
        Invoke("LoadRoom1", animationDuration);
    }

    // Methode zum Laden der neuen Szene
    private void LoadGameScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}