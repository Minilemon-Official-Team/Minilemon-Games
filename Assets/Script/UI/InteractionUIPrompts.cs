using TMPro;
using UnityEngine;

public class InteractionUIPrompts : MonoBehaviour
{
    public GameObject interactionUIPanel;
    public TextMeshProUGUI UIText;
    private PlayerInteraction playerInteraction;

    private void OnEnable()
    {
        playerInteraction = FindObjectOfType<PlayerInteraction>();

        if (playerInteraction != null)
        {
            playerInteraction.OnInteractableDetected += ShowInteractionUI;
            playerInteraction.OnInteractableLost += HideInteractionUI;
        }
    }

    private void OnDisable()
    {
        if (playerInteraction != null)
        {
            playerInteraction.OnInteractableDetected -= ShowInteractionUI;
            playerInteraction.OnInteractableLost -= HideInteractionUI;
        }
    }

    void ShowInteractionUI(string interactableName)
    {
        if (interactionUIPanel != null)
        {
            UIText.text = "Interact With " + interactableName;
            interactionUIPanel.SetActive(true);
        }
    }

    void HideInteractionUI()
    {
        if (interactionUIPanel != null)
        {
            interactionUIPanel.SetActive(false);
        }
    }
}