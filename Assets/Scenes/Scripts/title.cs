using UnityEngine;
using UnityEngine.UI;

public class TitleScreenManager : MonoBehaviour
{
    public GameObject titleText;
    public GameObject buttonsContainer;

    private bool titleClicked = false;

    void Start()
    {
        // Stelle sicher, dass nur der Titel sichtbar ist
        titleText.SetActive(true);
        buttonsContainer.SetActive(false);
    }

    void Update()
    {
        if (!titleClicked && Input.GetMouseButtonDown(0))
        {
            ShowButtons();
        }
    }

    void ShowButtons()
    {
        titleClicked = true;
        titleText.SetActive(false);
        buttonsContainer.SetActive(true);
    }
}