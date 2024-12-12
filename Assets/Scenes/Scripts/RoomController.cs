using UnityEngine;

public class RoomController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector2 offset;
    private bool isDragging;

    public Vector2 correctPosition;  // Die korrekte Position des Raums
    private Vector2 originalPosition; // Ursprüngliche Position des Raums

    public bool IsPlacedCorrectly { get; private set; } = false; // Status, ob der Raum korrekt platziert ist

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.isKinematic = true; // Verhindert, dass die Physik auf das Objekt angewendet wird
        originalPosition = rb2d.position; // Speicher die Ausgangsposition
    }

    void Update()
    {
        if (isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rb2d.position = mousePosition + offset;
        }
    }

    void OnMouseDown()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = (Vector2)transform.position - mousePosition;
        isDragging = true;
    }

    void OnMouseUp()
    {
        isDragging = false;
        // Überprüfen, ob der Raum in der richtigen Position ist
        if (Vector2.Distance(rb2d.position, correctPosition) < 1f)
        {
            rb2d.position = correctPosition;  // Setze den Raum an die Zielposition
            IsPlacedCorrectly = true; // Markiere den Raum als korrekt platziert
            Debug.Log("Raum korrekt platziert!");
        }
        else
        {
            rb2d.position = originalPosition;  // Raum zurücksetzen, wenn er nicht richtig ist
            IsPlacedCorrectly = false;
        }
    }
}