using UnityEngine;
using UnityEngine.EventSystems;

public class IntroOverlayClick : MonoBehaviour, IPointerClickHandler
{
    // Statische Variable, damit dieser Ablauf nur einmal passiert
    private static bool introShown = false;

    void Start()
    {
        if (!introShown)
        {
            // Overlay anzeigen und Spiel pausieren
            gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            // Falls schon gezeigt: Overlay ausblenden
            gameObject.SetActive(false);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!introShown)
        {
            // Overlay ausblenden und Spiel fortsetzen
            gameObject.SetActive(false);
            Time.timeScale = 1f;
            introShown = true;
        }
    }
}
