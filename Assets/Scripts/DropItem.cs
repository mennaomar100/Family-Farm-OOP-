using UnityEngine;

public class DropItem : MonoBehaviour, IInteractable
{
    [SerializeField] private ResourceManager resourceManager;


    private void Start()
    {
        resourceManager = resourceManager = FindFirstObjectByType<ResourceManager>();
    }
    public void Interact(HeldItem heldItem, PlayerInteraction player)
    {
        if (heldItem != HeldItem.Basket)
        {
            Debug.Log("Need Basket");
            return;
        }

        Collect(player);
    }

    private void Collect(PlayerInteraction player)
    {
      

        if (CompareTag("WoodDrop"))
        {
           resourceManager.AddWood();
        }

        else if (CompareTag("RockDrop"))
        {
           resourceManager.AddRock();
        }
        Destroy(gameObject);
    }
}