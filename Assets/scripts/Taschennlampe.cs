using System.Collections; // WICHTIG: Fügt IEnumerator hinzu
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ButtonClickHandler : MonoBehaviour
{
    public Button myButton;
    public Image newImage;

    void Start()
    {
        newImage.gameObject.SetActive(false);
        myButton.onClick.AddListener(OnButtonClick);
    }

    void OnButtonClick()
    {
        myButton.interactable = false;
        newImage.gameObject.SetActive(true);
        InventoryManager.Instance.CollectItem("Flashlight"); // Item in UI anzeigen
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Room1");
    }
}
