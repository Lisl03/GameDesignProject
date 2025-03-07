using UnityEngine;

public class RoomController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector2 offset;
    private bool isDragging;

    public Vector2 correctPosition;  // The correct position for the room
    private Vector2 originalPosition; // The original position of the room

    public bool IsPlacedCorrectly { get; private set; } = false; // Whether the room is placed correctly

    private SpriteRenderer spriteRenderer; // Reference to the room's SpriteRenderer
    private int defaultSortingOrder = 0;   // Default sorting order for rendering

    void Start()
    {
        // Initialize the Rigidbody2D and set it to kinematic
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.bodyType = RigidbodyType2D.Kinematic;  // Set to kinematic using bodyType

        // Store the original position of the room
        originalPosition = rb2d.position;

        // Get the SpriteRenderer component of the room
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        // Store the default sorting order for rendering
        defaultSortingOrder = spriteRenderer.sortingOrder;
    }

    void Update()
    {
        // If the room is being dragged
        if (isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rb2d.position = mousePosition + offset; // Move the room with the mouse
        }
    }

    void OnMouseDown()
    {
        // Set the offset when the room is clicked
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = (Vector2)transform.position - mousePosition;
        isDragging = true;

        // Select the room (bring it to the front)
        SelectRoom();
    }

    void OnMouseUp()
    {
        isDragging = false;

        // Check if the room is in the correct position
        if (Vector2.Distance(rb2d.position, correctPosition) < 1f)
        {
            rb2d.position = correctPosition;  // Set the room to the correct position
            IsPlacedCorrectly = true; // Mark the room as correctly placed
            Debug.Log("Room correctly placed!");
        }
        else
        {
            rb2d.position = originalPosition;  // Reset the room if it is not correct
            IsPlacedCorrectly = false;
        }

        // Reset the sorting order after the room is released
        DeselectRoom();
    }

    // Bring the room to the front by adjusting its sorting order
    public void SelectRoom()
    {
        spriteRenderer.sortingOrder = 10;  // Set the sorting order to a higher value
    }

    // Reset the sorting order when the room is released
    public void DeselectRoom()
    {
        spriteRenderer.sortingOrder = defaultSortingOrder;  // Reset to the default sorting order
    }
}
