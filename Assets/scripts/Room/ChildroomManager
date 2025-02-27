using UnityEngine;

public class ChildroomManager : MonoBehaviour
{
    public static ChildroomManager Instance;

    public GameObject mirror;
    public GameObject diary;
    public GameObject plushie;

    private bool diaryCollected = false;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        diary.SetActive(false);
        plushie.SetActive(false);
    }

    public void TriggerMirrorDialogue()
    {
        DialogueManager.Instance.StartDialogue("Mirror");
        DialogueManager.Instance.OnDialogueEnd += UnlockDiary;
    }

    void UnlockDiary()
    {
        DialogueManager.Instance.OnDialogueEnd -= UnlockDiary;
        diary.SetActive(true);
    }

    public void CollectDiary()
    {
        diaryCollected = true;
        plushie.SetActive(true);
    }
}
