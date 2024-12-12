using UnityEngine;

public class BookAnimationController : MonoBehaviour
{
    public Animator bookAnimator;  // Animator des Buches
    public string openAnimation = "BookOpens";  // Der Name der Animations-Clip für das Öffnen des Buches
    public string flipAnimation = "FlipPages";  // Der Name der Animations-Clip für das Umblättern der Seiten

    public GameObject saveButton;
    public GameObject exitButton;
    public GameObject continueButton;

    private void Start()
    {
        // Initiale Sichtbarkeit der Buttons
        saveButton.SetActive(false);
        exitButton.SetActive(false);
        continueButton.SetActive(false);
    }

    // Wird aufgerufen, wenn das Buch geöffnet wird
    public void OpenBook()
    {
        bookAnimator.SetTrigger(openAnimation);
        // Buttons erst nach dem Öffnen des Buches aktivieren
        Invoke("ShowMenuButtons", 1f); // Verzögert das Anzeigen der Buttons
    }

    // Zeigt die Buttons nach der Öffnungs-Animation
    void ShowMenuButtons()
    {
        saveButton.SetActive(true);
        exitButton.SetActive(true);
        continueButton.SetActive(true);
    }

    // Umblätter-Animation für den Weiter-Button
    public void FlipPages()
    {
        bookAnimator.SetTrigger(flipAnimation);

    }
      public void TriggerBookOpenAnimation()
    {
        // Stelle sicher, dass der Animator vorhanden ist und die Animation ausgeführt wird
        if (bookAnimator != null)
        {
            bookAnimator.SetTrigger("OpenBook");  // Setze den "OpenBook"-Trigger
        }
    }
}

