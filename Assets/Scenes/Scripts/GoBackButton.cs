using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GoBackButton : MonoBehaviour
{
    private static Stack<string> sceneHistory = new Stack<string>();

    void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        // Falls der Stack leer ist oder die letzte Szene nicht die aktuelle ist, speichern
        if (sceneHistory.Count == 0 || sceneHistory.Peek() != currentScene)
        {
            sceneHistory.Push(currentScene);
        }
    }

    public void GoBack()
    {
        if (sceneHistory.Count > 1)
        {
            // Entferne die aktuelle Szene
            sceneHistory.Pop();

            // Lade die vorherige Szene
            string previousScene = sceneHistory.Peek();
            SceneManager.LoadScene(previousScene);
        }
        else
        {
            Debug.Log("Keine vorherige Szene gespeichert.");
        }
    }
}
