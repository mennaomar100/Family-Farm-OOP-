using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResourceManager : MonoBehaviour
{
    [SerializeField] private GameObject trees;
    [SerializeField] private GameObject rocks;

    [SerializeField] private TextMeshProUGUI rockDropCountText;
    [SerializeField] private TextMeshProUGUI woodDropCountText;
    [SerializeField] private TextMeshProUGUI flowerCountText;




    private int rockDropCount;
    private int woodDropCount;
    private int flowerCount = 0;
    private int totalWoodCollected;
    private int totalRocksCollected;



    public void AddWood()
    {
        woodDropCount++;
        totalWoodCollected++;

        Debug.Log("Wood Drops: " + totalWoodCollected);
        woodDropCountText.text = "Wood: " + totalWoodCollected;

    }
    public void RemoveWood(int amount)
    {
        woodDropCount -= amount;
    }

    public void AddRock()
    {
        rockDropCount++;
        totalRocksCollected++;

        Debug.Log("Rock Drops: " + totalRocksCollected);
        rockDropCountText.text = "Rocks: " + totalRocksCollected;
    }
    public void RemoveRock(int amount)
    {
        rockDropCount -= amount;
    }
    public void AddFlower()
    {
        flowerCount++;
        if (flowerCountText != null)
        {
            flowerCountText.text = "Flowers: " + flowerCount;
        }
    }


    public void ReviveTrees()
    {
       
        if (totalWoodCollected >= 6)
        {
            RemoveWood(6);

            Instantiate(trees);
        }
    }
    public void ReviveRocks()
    {
       

        if (totalRocksCollected >= 2)
        {
            RemoveRock(2);

            Instantiate(rocks);
        }
    }
    
   

}
