using UnityEngine;
using UnityEngine.SceneManagement; // Zum Laden von Szenen

public class SceneChanger : MonoBehaviour
{
    // Diese Methode wird beim Button-Klick aufgerufen
    public void ChangeScene()
    {
        SceneManager.LoadScene("Room1"); // Ersetze "DeineZielSzene" mit dem Namen deiner Zielszene
    }
}