using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private HeldItem currentHeldItem;
    [SerializeField] private GameObject axeVisual;
    [SerializeField] private GameObject basketVisual;
    [SerializeField] private GameObject waterCanVisual;
    

    private IInteractable currentInteractable;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentInteractable?.Interact(currentHeldItem, this);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInteractable interactable = collision.GetComponent<IInteractable>();

        if (interactable != null)
        {
            currentInteractable = interactable;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IInteractable interactable = collision.GetComponent<IInteractable>();

        if (interactable != null &&
            interactable == currentInteractable)
        {
            currentInteractable = null;
        }
    }

   
    public HeldItem GetHeldItem()
    {
        return currentHeldItem;
    }

    public void SetHeldItem(HeldItem newItem)
    {
        currentHeldItem = newItem;
        UpdateVisuals();

        Debug.Log("Current Tool: " + currentHeldItem);
    }

    private void UpdateVisuals()
    {
        axeVisual.SetActive(false);
        basketVisual.SetActive(false);
        waterCanVisual.SetActive(false);

        switch (currentHeldItem)
        {
            case HeldItem.Axe:
                axeVisual.SetActive(true);
                break;

            case HeldItem.Basket:
                basketVisual.SetActive(true);
                break;

            case HeldItem.WaterCan:
                waterCanVisual.SetActive(true);
                break;
        }
    }

}