using UnityEngine;
using UnityEngine.SceneManagement; // für den Szenenwechsel

public class FlashlightController : MonoBehaviour
{
    public Material flashlightMaterial;
    public Camera mainCamera;
    public float flashlightRadius = 0.2f;
    
    // Referenzen zu den Schrank-Hintergrunds-Sprites
    public SpriteRenderer cabinetLightRenderer;
    public SpriteRenderer cabinetDarkRenderer;
    public Sprite cabinetClosedSprite; // Standard: geschlossener Schrank
    public Sprite cabinetOpenSprite;   // Geöffneter Schrank

    // Das Item-Bild, das später angezeigt werden soll
    public GameObject itemImage;

    void Update()
    {
        // Update für den Lichtkegel
        UpdateFlashlight();

        // 2D Raycast von der Mausposition aus
        Vector2 mousePos2D = new Vector2(mainCamera.ScreenToWorldPoint(Input.mousePosition).x, mainCamera.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        if (hit.collider != null && hit.collider.CompareTag("Cabinet"))
        {
            // Wenn die Maus über dem Schrank-Collider ist:
            cabinetLightRenderer.sprite = cabinetOpenSprite;
            cabinetDarkRenderer.sprite = cabinetOpenSprite;
            // Item-Bild einblenden
            itemImage.SetActive(true);
        }
        else
        {
            // Optional: Bei Verlassen des Bereichs wieder zurücksetzen
            cabinetLightRenderer.sprite = cabinetClosedSprite;
            cabinetDarkRenderer.sprite = cabinetClosedSprite;
            itemImage.SetActive(false);
        }
    }

    void UpdateFlashlight()
    {
        // Mausposition in Weltkoordinaten holen
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0; // Sicherstellen, dass die Z-Koordinate auf 0 bleibt (2D)

        // Mausposition und Radius an den Shader senden
        Vector2 mouseUVPos = mainCamera.WorldToViewportPoint(mouseWorldPos);
        flashlightMaterial.SetVector("_MousePos", mouseUVPos);
        flashlightMaterial.SetFloat("_Radius", flashlightRadius);
    }
}
