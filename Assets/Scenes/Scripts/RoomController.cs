using UnityEngine;

public class RoomController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector2 offset;
    private bool isDragging;

    public Vector2 correctPosition;  // Die korrekte Position des Raums
    private Vector2 originalPosition; // Ursprüngliche Position des Raums

    public bool IsPlacedCorrectly { get; private set; } = false; // Status, ob der Raum korrekt platziert ist

    private SpriteRenderer spriteRenderer; // Referenz auf den SpriteRenderer des Raumes
    private int defaultSortingOrder = 0;   // Standard-Sorting Order

    void Start()
    {
        // Initialisiere den Rigidbody2D und setze ihn auf kinematisch
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.isKinematic = true;  // Verhindert, dass die Physik auf das Objekt angewendet wird

        // Speichere die Ausgangsposition
        originalPosition = rb2d.position;

        // Hole die SpriteRenderer-Komponente des Raumes
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        // Speichere die Standard-Sorting Order
        defaultSortingOrder = spriteRenderer.sortingOrder;
    }

    void Update()
    {
        // Wenn der Raum gerade gezogen wird
        if (isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rb2d.position = mousePosition + offset;
        }
    }

    void OnMouseDown()
    {
        // Setze den Offset, wenn der Raum mit der Maus angeklickt wird
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = (Vector2)transform.position - mousePosition;
        isDragging = true;

        // Wähle den Raum aus und setze ihn nach vorne
        SelectRoom();
    }

    void OnMouseUp()
    {
        isDragging = false;

        // Überprüfe, ob der Raum in der richtigen Position ist
        if (Vector2.Distance(rb2d.position, correctPosition) < 1f)
        {
            rb2d.position = correctPosition;  // Setze den Raum an die Zielposition
            IsPlacedCorrectly = true; // Markiere den Raum als korrekt platziert
            Debug.Log("Raum korrekt platziert!");
        }
        else
        {
            rb2d.position = originalPosition;  // Setze den Raum zurück, wenn er nicht richtig ist
            IsPlacedCorrectly = false;
        }

        // Setze die Sorting Order zurück, wenn der Raum abgesetzt wurde
        DeselectRoom();
    }

    // Wähle den Raum aus und setze ihn nach vorne
    public void SelectRoom()
    {
        spriteRenderer.sortingOrder = 10;  // Setze die Sorting Order auf einen höheren Wert, damit der Raum vorne ist
    }

    // Setze die Sorting Order zurück, wenn der Raum abgesetzt wurde
    public void DeselectRoom()
    {
        spriteRenderer.sortingOrder = defaultSortingOrder;  // Setze die Sorting Order auf den Standardwert
    }
}
