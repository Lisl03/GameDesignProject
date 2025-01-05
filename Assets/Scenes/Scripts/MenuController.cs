using UnityEngine;
using UnityEngine.UI;

public class BookMenuController : MonoBehaviour
{
    public GameObject bookUI; // Das Buch UI GameObject
    public Animator bookAnimator; // Animator für das Buch
    public GameObject buttonsPanel; // Panel, das die Buttons enthält
    public GameObject photoAlbum; // UI für das Fotoalbum
    public GameObject inventory; // UI für das Inventar

    private bool isBookOpen = false; // Status des Buchs

    void Start()
    {
        // Initial: Buch und Buttons verstecken
        bookUI.SetActive(false);
        buttonsPanel.SetActive(false);
        photoAlbum.SetActive(false);
        inventory.SetActive(false);
    }

    void Update()
    {
        // Buch mit Escape öffnen/schließen
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isBookOpen)
            {
                CloseBook();
            }
            else
            {
                OpenBook();
            }
        }
    }

    public void OpenBook()
    {
        isBookOpen = true;
        Time.timeScale = 0f; // Spiel pausieren
        bookUI.SetActive(true); // Buch sichtbar machen
        bookAnimator.SetTrigger("OpenBook"); // OpenBook Animation starten
        Invoke("ShowButtons", 1f); // Buttons nach Animation anzeigen (Dauer anpassen)
    }

    public void CloseBook()
    {
        isBookOpen = false;
        Time.timeScale = 1f; // Spiel fortsetzen
        bookUI.SetActive(false); // Buch verstecken
        buttonsPanel.SetActive(false); // Buttons verstecken
        photoAlbum.SetActive(false); // Fotoalbum schließen
        inventory.SetActive(false); // Inventar schließen
    }

    public void ShowButtons()
    {
        buttonsPanel.SetActive(true); // Buttons nach Buch-Animation anzeigen
    }

    public void FlipPage()
    {
        buttonsPanel.SetActive(false); // Buttons verstecken, während Seite umgeblättert wird
        bookAnimator.SetTrigger("FlipPage"); // FlipPage Animation starten
        Invoke("ShowNextPage", 1f); // Nächste Seite nach Animation anzeigen (Dauer anpassen)
    }

    private void ShowNextPage()
    {
        if (photoAlbum.activeSelf)
        {
            // Nächstes ist das Inventar
            photoAlbum.SetActive(false);
            inventory.SetActive(true);
        }
        else if (inventory.activeSelf)
        {
            // Wenn Inventar offen ist, zurück zu den Buttons
            inventory.SetActive(false);
            buttonsPanel.SetActive(true);
        }
        else
        {
            // Erstes Umblättern: Fotoalbum öffnen
            photoAlbum.SetActive(true);
        }
    }

    public void SaveGame()
    {
        Debug.Log("Spiel gespeichert!");
        // Hier kannst du deinen Speicherlogik hinzufügen
    }

    public void ExitGame()
    {
        Debug.Log("Spiel beendet!");
        Application.Quit();
    }

    public void OpenSettings()
    {
        Debug.Log("Einstellungen öffnen!");
        // Öffne ein weiteres Menü oder Einstellungen
    }
}
