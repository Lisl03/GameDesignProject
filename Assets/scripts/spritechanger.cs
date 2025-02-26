using UnityEngine;

public class spritechanger : MonoBehaviour

{
    public string detectionTag = "SpecialObject"; // Tag der Objekte, bei denen sich der Sprite ändert
    public Sprite newSprite; // Der neue Sprite, der angezeigt wird
    private Sprite originalSprite;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalSprite = spriteRenderer.sprite; // Speichert den ursprünglichen Sprite
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(detectionTag) && spriteRenderer != null)
        {
            spriteRenderer.sprite = newSprite;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(detectionTag) && spriteRenderer != null)
        {
            spriteRenderer.sprite = originalSprite;
        }
    }
}