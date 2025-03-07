using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WardrobePuzzle : MonoBehaviour
{
    public GameObject enlargedBox;   // Vergrößerte Schachtel
    public GameObject enlargedHat;   // Vergrößerter Hut
    public GameObject enlargedDrawer; // Vergrößerte Schublade
    public GameObject dollDress;      // Puppenkleid in der Schachtel
    public GameObject inventorySlot;  // UI-Element für das Puppenkleid im Inventar

    private bool isBoxOpen = false; 

    private bool isDressCollected = false;
    

    // Methode, um ein vergrößertes Objekt zu öffnen/schließen
    public void ToggleObject(GameObject obj)
    {
        // Prüfen, ob das Objekt bereits aktiv ist
        if (obj.activeSelf)
        {
            obj.SetActive(false); // Falls aktiv, ausblenden
        }
        else
        {
            // Erst alle anderen schließen
            enlargedBox.SetActive(false);
            enlargedHat.SetActive(false);
            enlargedDrawer.SetActive(false);

            obj.SetActive(true); // Dann das gewünschte Objekt anzeigen
        }
    }

    // Methode für die Schachtel
    public void ClickBox()
    {
        ToggleObject(enlargedBox);
        isBoxOpen = enlargedBox.activeSelf; // Speichert, ob die Schachtel offen ist

        // Puppenkleid nur anzeigen, wenn Schachtel offen ist
        dollDress.SetActive(isBoxOpen);
    }

    // Methode für das Puppenkleid
 public void CollectDress()
{
    if (isBoxOpen)
    {
        dollDress.SetActive(false); // Puppenkleid aus der Schachtel entfernen

        // Item ins Inventar legen über das Event-System
        if (GameEvents.instance != null)
        {
            GameEvents.instance.ItemCollected("DollDress");
        }

        // Speichern, dass das Kleid eingesammelt wurde
        PlayerPrefs.SetInt("DressCollected", 1);
        PlayerPrefs.Save(); // Speichert den Wert dauerhaft

        SceneManager.LoadScene("Room1"); // Szene wechseln
    }
}

}