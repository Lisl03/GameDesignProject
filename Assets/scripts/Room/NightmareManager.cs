using UnityEngine;

public class NightmareManager : MonoBehaviour
{
    void Start()
    {
        GameMaster.Instance.ChangeEmotionalStability(-50);
    }

    void Update()
    {
        if (GameMaster.Instance.emotionalStability > 50)
        {
            EndNightmare();
        }
    }

    void EndNightmare()
    {
        GameMaster.Instance.LoadNextRoom();
    }
}
