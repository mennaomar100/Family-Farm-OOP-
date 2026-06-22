using UnityEngine;

public abstract class Breakable : MonoBehaviour, IInteractable
{
    protected virtual int hitsToBreak => 3;  //we make it a property.
    protected int currentHits;

    [SerializeField] protected GameObject dropPrefab;
    protected int dropCount;

    public void Interact(HeldItem heldItem, PlayerInteraction player)
    {
        if (heldItem != HeldItem.Axe)
        {
            Debug.Log("Need Axe");
            return;
        }

        Hit();
    }

    protected void Hit()
    {
        currentHits++;

        Debug.Log(gameObject.name + " hit: " + currentHits);

        if (currentHits >= hitsToBreak)
        {
            Break();
        }
    }

    protected virtual void Break()
    {
        Drop();

        Destroy(gameObject);
    }

    protected virtual void Drop()
    {
        if (dropPrefab != null)
        {
            Instantiate(dropPrefab, transform.position, Quaternion.identity);
        }
    }
   
}           