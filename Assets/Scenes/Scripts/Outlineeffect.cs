using UnityEngine;

public class OutlineEffect : MonoBehaviour
{
    private Material material;
    public Color outlineColor = Color.white;

    private void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            material.SetColor("_OutlineColor", outlineColor);
            material.SetFloat("_OutlineWidth", 1f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            material.SetFloat("_OutlineWidth", 0f);
        }
    }
}
