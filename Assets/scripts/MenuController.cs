using UnityEngine;
using UnityEngine.SceneManagement;

public class BookMenuController : MonoBehaviour
{
    public GameObject bookButton;  // Das Buch-Symbol im Spiel
    public string menuSceneName = "Menu";  // Name der Szene, zu der gewechselt werden soll

    private bool isBookOpen = false;  // Überwacht, ob das Buch angezeigt wird

    void Update()
    {
        // Öffne das Buch, wenn ESC gedrückt wird
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleBookMenu();
        }
    }

    void ToggleBookMenu()
    {
        isBookOpen = !isBookOpen;
        if (isBookOpen)
        {
            // Zeige das Buch-Menü
            bookButton.SetActive(false);  // Verstecke das Buch im Spiel
            SceneManager.LoadScene(menuSceneName);  // Lade die Menü-Szene
        }
        else
        {
            // Das Buch schließen (optional, kannst du nach Bedarf anpassen)
            bookButton.SetActive(true);
        }
    }
}