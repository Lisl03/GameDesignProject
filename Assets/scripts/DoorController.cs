using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Sprite openDoorSprite;  // Sprite für offene Tür
    public Sprite closedDoorSprite; // Sprite für geschlossene Tür
    public float detectionRadius = 2f; // Radius, in dem der Spieler erkannt wird
    public Transform player; // Referenz zum Spieler-Transform

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = closedDoorSprite; // Standardmäßig geschlossene Tür
    }

    void Update()
    {
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.position);
            if (distance <= detectionRadius)
            {
                spriteRenderer.sprite = openDoorSprite;
            }
            else
            {
                spriteRenderer.sprite = closedDoorSprite;
            }
        }
    }
}