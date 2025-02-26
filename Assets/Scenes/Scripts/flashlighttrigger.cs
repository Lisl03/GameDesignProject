using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;  // Für die Coroutine

public class FlashlightColliderTrigger : MonoBehaviour
{
    public SpriteRenderer openedBoxSprite;  // Das Sprite der geöffneten Box
    public string nextSceneName = "Room1"; // Name der nächsten Szene
    private bool puzzleSolved = false;

    void Start()
    {
        // Das Sprite am Anfang unsichtbar machen
        if (openedBoxSprite != null)
            openedBoxSprite.gameObject.SetActive(false);
    }

    void Update()
    {
        // Mausposition in Weltkoordinaten berechnen
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;

        // Prüfen, ob Maus über Collider ist
        Collider2D boxCollider = GetComponent<Collider2D>();
        if (boxCollider != null && boxCollider.OverlapPoint(mouseWorldPos) && !puzzleSolved)
        {
            SolvePuzzle();
        }
    }

    void SolvePuzzle()
    {
        puzzleSolved = true;
        Debug.Log("Puzzle gelöst! Schachtel geöffnet.");

        // Sprite der geöffneten Box sichtbar machen
        if (openedBoxSprite != null)
            openedBoxSprite.gameObject.SetActive(true);
    }

    void OnMouseDown()
    {
        if (puzzleSolved)
        {
            Debug.Log("Taschenlampe angeklickt! Szene wechselt...");

            // Starte die Coroutine, die die Szene nach 2 Sekunden wechselt
            StartCoroutine(WechsleSzeneNachZeit(2f));  // 2 Sekunden Verzögerung
        }
    }

    // Coroutine, die die Szene nach einer bestimmten Zeit wechselt
    private IEnumerator WechsleSzeneNachZeit(float delay)
    {
        // Warte die angegebene Zeit (2 Sekunden)
        yield return new WaitForSeconds(delay);

        // Wechsle zur angegebenen Szene
        SceneManager.LoadScene(nextSceneName);
    }
}
