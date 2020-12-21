using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArtworkCollider : MonoBehaviour
{
    [SerializeField]
    private GameObject interactionUI;
    public bool IsArtworkInteractable = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ActiveInteractionUI(interactionUI);
            IsArtworkInteractable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(interactionUI.activeInHierarchy == true)
        {
            DeactiveInteractionUI(interactionUI);
            IsArtworkInteractable = false;
        }
    }

    void ActiveInteractionUI(GameObject UIMenu)
    {
        UIMenu.SetActive(true);
    }

    void DeactiveInteractionUI(GameObject UIMenu)
    {
        UIMenu.SetActive(false);
    }

    public void ActiveObserveMode()
    {
        SceneManager.LoadScene("05_ObserveModeUI");
    }
}
