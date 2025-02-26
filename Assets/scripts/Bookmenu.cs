using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BookMenu : MonoBehaviour
{
    public Animator bookAnimator;
    public GameObject buttonsContainer; // Container für die Buttons
    public Button flipPageButton;
    public GameObject newButton; // Neuer Button nach Animation
    
    void Start()
    {
        buttonsContainer.SetActive(false); // Verstecke Buttons zu Beginn
        newButton.SetActive(false); // Neuer Button unsichtbar
        StartCoroutine(ShowButtonsAfterAnimation());
        flipPageButton.onClick.AddListener(FlipPage);
    }

    IEnumerator ShowButtonsAfterAnimation()
    {
        yield return new WaitUntil(() => bookAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1);
        buttonsContainer.SetActive(true);
    }

    void FlipPage()
    {
        buttonsContainer.SetActive(false); // Verstecke alle Buttons
        bookAnimator.SetTrigger("FlipPage"); // Starte Umblätter-Animation
        StartCoroutine(ShowNewButtonAfterAnimation());
    }

    IEnumerator ShowNewButtonAfterAnimation()
    {
        yield return new WaitUntil(() => bookAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1);
        newButton.SetActive(true); // Zeige neuen Button nach Animation
    }
}
