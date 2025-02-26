using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TaschenlampeItem : MonoBehaviour
{
    [Header("Szenenwechsel")]
    public GameObject schubladeLeerImage;  // Bild der leeren Schublade (wird nach dem Klick angezeigt)
    public string sceneName;               // Name der Szene, in die gewechselt werden soll

    [Header("Item-Einstellungen")]
    public string itemName = "Taschenlampe"; // Eindeutiger Name für das Item (wird in PlayerPrefs gespeichert)
    public Sprite itemSprite;              // Bild des Items, das dem Inventar hinzugefügt wird

    private bool isCollected = false;

    void Start()
    {
        // Prüfen, ob das Item bereits eingesammelt wurde
        if (PlayerPrefs.GetInt(itemName, 0) == 1)
        {
            Destroy(gameObject);
            return;
        }

        // Das Bild der leeren Schublade zu Beginn unsichtbar machen
        if (schubladeLeerImage != null)
        {
            schubladeLeerImage.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        if (!isCollected)
        {
            // Item zum Inventar hinzufügen
            InventoryManager inventory = FindObjectOfType<InventoryManager>();
            if (inventory != null && itemSprite != null)
            {
                inventory.AddItem(itemSprite);
            }

            // Speichern, dass das Item eingesammelt wurde
            PlayerPrefs.SetInt(itemName, 1);
            PlayerPrefs.Save();
            isCollected = true;

            // Das GameObject (das Item) deaktivieren und das Bild der leeren Schublade anzeigen
            gameObject.SetActive(false);
            if (schubladeLeerImage != null)
            {
                schubladeLeerImage.SetActive(true);
            }

            // Nach 2 Sekunden die Szene wechseln
            Invoke("WechselSzene", 2f);
        }
    }

    void WechselSzene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
