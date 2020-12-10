using System;
using UnityEngine;

public class ActivateInteraction : MonoBehaviour
{
    [SerializeField] private GameObject highlightArea;
    [SerializeField] private PlayerInput playerInput;
    public static Action startObserveMode;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            highlightArea.SetActive(true);
            if (playerInput.InteractionInput == true)
            {
                startObserveMode();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            highlightArea.SetActive(false);
        }
    }
}
