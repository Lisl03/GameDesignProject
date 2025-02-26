using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [Tooltip("Name der Szene, zu der gewechselt werden soll. Diese Szene muss in den Build Settings hinzugefügt sein.")]
    public string sceneName;

    // Diese Methode wird beim Button-Klick aufgerufen
    public void SwitchScene()
    {
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogError("Szene nicht gesetzt! Bitte füge im Inspector einen gültigen Szenennamen hinzu.");
            return;
        }
        
        SceneManager.LoadScene(sceneName);
    }
}
