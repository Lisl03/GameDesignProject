using UnityEngine;
using UnityEngine.UI; // Damit wir auf UI-Elemente zugreifen können

public class QuitButtonScript : MonoBehaviour
{
    public Button quitButton; // Referenz auf den Button

    void Start()
    {
        // Überprüfen, ob der Button zugewiesen ist
        if (quitButton != null)
        {
            quitButton.onClick.AddListener(QuitGame); // Füge Listener hinzu, der beim Klicken das Spiel beendet
        }
    }

    void QuitGame()
    {
        // Wenn wir im Editor sind, stoppen wir das Spiel
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit(); // Beendet das Spiel, wenn es als Build läuft
        #endif
    }
}
