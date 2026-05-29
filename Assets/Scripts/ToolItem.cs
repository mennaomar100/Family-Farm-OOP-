using UnityEngine;

public class ToolPickup : MonoBehaviour, IInteractable
{
    [SerializeField] private HeldItem toolType;
 

    public void Interact(HeldItem heldItem, PlayerInteraction player)
    {
        

        // Pick up tool if empty handed
        if (heldItem == HeldItem.None)
        {
            player.SetHeldItem(toolType);
          

            return;
        }

        // Put tool away if same tool
        if (heldItem == toolType)
        {
            player.SetHeldItem(HeldItem.None);
        
        }
    }
}