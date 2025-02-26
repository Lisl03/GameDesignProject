using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public void SaveAndExit()
    {
        SaveGame(); // Spiel speichern
        SceneManager.LoadScene("TitleScreen"); // Zurück zum Titelbildschirm
    }

    private void SaveGame()
    {
        // Beispiel: Spielerposition speichern (Falls du mehr speicherst, passe es an)
        PlayerPrefs.SetInt("PlayerScore", 100); // Beispiel für einen Punktestand
        PlayerPrefs.SetFloat("PlayerX", transform.position.x); 
        PlayerPrefs.SetFloat("PlayerY", transform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", transform.position.z);
        
        PlayerPrefs.Save(); // Speicher die Daten dauerhaft
        Debug.Log("Spiel gespeichert!");
    }
}
