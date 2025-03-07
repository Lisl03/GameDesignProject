using UnityEngine;
using UnityEngine.EventSystems;

public class CursorManager : MonoBehaviour
{
    public Texture2D customCursor; // Benutzerdefinierte Cursor-Textur
    public Texture2D defaultCursor; // Standard-Cursor-Textur
    public bool lockCursor = false; // Soll der Cursor gesperrt werden?

    void Start()
    {
        SetCursor(defaultCursor);
        if (lockCursor)
        {
            LockCursor(true);
        }
    }

    // Setzt den Cursor auf eine bestimmte Textur
    public void SetCursor(Texture2D cursorTexture)
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    // Sperrt oder entsperrt den Cursor
    public void LockCursor(bool shouldLock)
    {
        if (shouldLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    // Diese Methode kann mit einem UI-Event (OnPointerEnter) verbunden werden
    public void ChangeCursor()
    {
        SetCursor(customCursor);
    }

    // Diese Methode kann mit einem UI-Event (OnPointerExit) verbunden werden
    public void ResetCursor()
    {
        SetCursor(defaultCursor);
    }
}