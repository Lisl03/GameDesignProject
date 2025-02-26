using UnityEngine;
using UnityEngine.SceneManagement;  // Zum Laden der Szene
using UnityEngine.UI;  // Für den Button
using System.Collections;  // Muss hinzugefügt werden, um IEnumerator zu verwenden

public class ButtonAnimationController : MonoBehaviour
{
    public Animator animator;  // Der Animator, der die Animationen enthält
    public string triggerName = "FallAsleep";  // Der Name des Triggers im Animator
    public string sceneName = "Room1";  // Die nächste Szene, die nach der Animation geladen wird
    public float animationDuration = 4f;  // Die Dauer der Animation, bevor die Szene gewechselt wird

    private Button button;
    
    // Verweise auf die anderen Buttons, die ausgeblendet werden sollen
    public GameObject exitButton;
    public GameObject settingsButton;
    public GameObject loadButton;
    public GameObject PlayButton;

    void Start()
    {
        // Finde den Button und füge einen Listener hinzu
        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }

    // Wird aufgerufen, wenn der Play-Button geklickt wird
    void OnButtonClick()
    {
        // Trigger die Animation
        if (animator != null)
        {
            animator.SetTrigger(triggerName);
        }

        // Blende die anderen Buttons aus
        if (exitButton != null)
        {
            exitButton.SetActive(false);
        }
        if (settingsButton != null)
        {
            settingsButton.SetActive(false);
        }
        if (loadButton != null)
        {
            loadButton.SetActive(false); 
        }
        if (PlayButton != null)
        {
            PlayButton.SetActive(false); 
        }

        // Mache den Play-Button unsichtbar (aber weiterhin aktiv)
        CanvasRenderer canvasRenderer = button.GetComponent<CanvasRenderer>();
        if (canvasRenderer != null)
        {
            canvasRenderer.SetAlpha(0f);  // Setzt die Transparenz auf 0 (unsichtbar)
        }

        // Starte Coroutine, um die Szene nach der Animation zu wechseln
        StartCoroutine(WaitForAnimationAndLoadScene());
    }

    // Coroutine wartet auf das Ende der Animation und lädt dann die neue Szene
    private IEnumerator WaitForAnimationAndLoadScene()
    {
        // Warte, bis die Animation vorbei ist (hier gehen wir von einer festen Dauer aus)
        yield return new WaitForSeconds(animationDuration);

        // Lade die nächste Szene
        SceneManager.LoadScene(sceneName);
    }
}
