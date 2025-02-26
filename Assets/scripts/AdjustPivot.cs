
using UnityEngine;

public class AdjustPivot : MonoBehaviour
{
    public Vector2 newPivot = new Vector2(0.5f, 0.5f); // Setzt den Pivot in die Mitte

    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.sprite = AdjustSpritePivot(sr.sprite, newPivot);
        }
    }

    Sprite AdjustSpritePivot(Sprite sprite, Vector2 pivot)
    {
        return Sprite.Create(sprite.texture, sprite.rect, pivot);
    }
}