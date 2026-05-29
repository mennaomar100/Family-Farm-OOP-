using TMPro;
using UnityEngine;

public class FarmTile : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject plantPrefab;

    [SerializeField] private ResourceManager resourceManager;

    private GameObject currentPlant;

    private bool hasSeed;

    private int waterCount;

    private bool isFullyGrown;

    private void Start()
    {
        resourceManager = FindFirstObjectByType<ResourceManager>();
    }
    public void Interact(HeldItem heldItem, PlayerInteraction player)
    {
        if (heldItem == HeldItem.None)
        {
            if (!hasSeed)
            {
                PlantSeed();
            }
        }

        else if (heldItem == HeldItem.WaterCan)
        {
            WaterCrop();
        }
        else if (heldItem == HeldItem.Basket && isFullyGrown)
        {
            HarvestCrop();
        }
    }

    private void PlantSeed()
    {
        hasSeed = true;

        currentPlant = Instantiate(plantPrefab,transform.position,Quaternion.identity);

        currentPlant.transform.localScale = Vector3.one * 0.5f;

        Debug.Log("Seed planted");
    }

    private void WaterCrop()
    {
        if (!hasSeed)
        {
            return;
        }

        if (isFullyGrown)
        {
            return;
        }

        waterCount++;

        currentPlant.transform.localScale += Vector3.one * 0.5f;

        Debug.Log("Crop watered");

        if (waterCount >= 3)
        {
            isFullyGrown = true;

            Debug.Log("Crop fully grown");
        }
    }

    private void HarvestCrop()
    {
        if (!isFullyGrown)
        {
            Debug.Log("Not ready to harvest");
            return; 
        }

        Destroy(currentPlant);
        Debug.Log("Crop harvested");

        hasSeed = false;
        isFullyGrown = false;
        waterCount = 0;

        resourceManager.AddFlower();
    }


}