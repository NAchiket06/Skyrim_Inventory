using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerInventory : MonoBehaviour
{
    public B_Inventory_UI inventoryUI; // handles inventory UI
    public List<GameObject> inventoryItem = new List<GameObject>(); // list that holds the items
    public GameObject playerItems; // parent object that holds the player items
    public Transform worldItems;


    public float Maxweight = 200f;
    public float currentWeight = 0f;

    [SerializeField] bool isInventoryActive;

    public Transform SpawnPos; // spawn position of instantiated objects

    private void Start()
    {
        inventoryUI.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isInventoryActive = !isInventoryActive;
        }
        if (isInventoryActive)
        {
            inventoryUI.enabled = true;
            if (Input.GetKeyDown(KeyCode.T))
            {
                RemoveItem();
            }
        }
        else inventoryUI.enabled = false;
    }

    private void RemoveItem()
    {
        if (inventoryItem.Count != 0)
        {
            
            inventoryUI.RemoveItem();
            GameObject item = inventoryItem[0];
            item.transform.SetParent(worldItems);
            item.SetActive(true);
            item.transform.localScale = item.GetComponent<ItemType>().item.scale;
            item.transform.position = SpawnPos.position;
            inventoryItem.Remove(inventoryItem[0]);
            Debug.Log("Removed from List");
        }
        
    }

    public bool AddItem(GameObject item)
    {

         float weight = item.GetComponent<ItemType>().item.weight;
        if (currentWeight + weight <= Maxweight)
        {
            AddInInventory(item);
            return true;

        }
        else return false;    
    }

    private void AddInInventory(GameObject item)
    {
        item.transform.SetParent(playerItems.transform);
        item.SetActive(false);
        inventoryItem.Add(item);
        inventoryUI.UpdateUI(playerItems);
    }

    void UpdateInventoryCanvas(Item item)
    {
        
    }
   
}
