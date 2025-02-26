using UnityEngine;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{
    public Animator animator;  // Verweise auf den Animator
    public GameObject dialogWindow;  // Verweis auf das Dialogfenster (UI-Element)
    public string firstAnimationName = "FirstAnimation";  // Name der ersten Animation
    public string secondAnimationName = "SecondAnimation"; // Name der zweiten Animation

    private void Start()
    {
        // Stelle sicher, dass das Dialogfenster zu Beginn ausgeblendet ist
        dialogWindow.SetActive(false);

        // Starte die erste Animation
        animator.Play(firstAnimationName);
    }

    // Diese Methode wird aufgerufen, wenn die erste Animation endet
    public void OnFirstAnimationEnd()
    {
        // Wechsle zur zweiten, loopernden Animation
        animator.Play(secondAnimationName);

        // Öffne das Dialogfenster
        dialogWindow.SetActive(true);
    }
}
