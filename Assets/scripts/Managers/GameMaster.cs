using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public static GameMaster Instance;

    public enum GameProgress { Childroom, LivingRoom, Bathroom, PlushieQuest, Nightmare, Complete }
    public GameProgress currentProgress = GameProgress.Childroom;

    public float emotionalStability = 100f;
    public InventoryManager inventory;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeEmotionalStability(float amount)
    {
        emotionalStability += amount;
        emotionalStability = Mathf.Clamp(emotionalStability, 0, 100);

        if (emotionalStability <= 0)
        {
            TriggerNightmare();
        }
    }

    public void LoadNextRoom()
    {
        switch (currentProgress)
        {
            case GameProgress.Childroom:
                currentProgress = GameProgress.LivingRoom;
                SceneManager.LoadScene("LivingRoom");
                break;
            case GameProgress.LivingRoom:
                currentProgress = GameProgress.Bathroom;
                SceneManager.LoadScene("Bathroom");
                break;
            case GameProgress.Bathroom:
                currentProgress = GameProgress.PlushieQuest;
                SceneManager.LoadScene("Childroom");
                break;
            case GameProgress.PlushieQuest:
                currentProgress = GameProgress.Nightmare;
                TriggerNightmare();
                break;
            case GameProgress.Nightmare:
                currentProgress = GameProgress.Complete;
                Debug.Log("Game Complete!");
                break;
        }
    }

    public void TriggerNightmare()
    {
        SceneManager.LoadScene("Nightmare");
    }
}
