using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerInventory : MonoBehaviour
{
    public B_Inventory_UI inventoryUI;
    public List<Item> inventoryItem = new List<Item>();

    public float Maxweight = 200f;
    public float currentWeight = 0f;

    bool isInventoryActive;

    public Transform SpawnPos;
    

    

    private void Start()
    {
         
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isInventoryActive = !isInventoryActive;
        }
        if (isInventoryActive)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                RemoveItem();
            }
        }
    }

    private void RemoveItem()
    {
        if (inventoryItem.Count != 0)
        {
            Instantiate(inventoryItem[0].obj,SpawnPos,true);
            inventoryUI.RemoveItem();           
            inventoryItem.Remove(inventoryItem[0]);
            Debug.Log("Removed from List");
        }
        
    }

    public void AddItem(Item item)
    {
        if(currentWeight + item.weight <= Maxweight)
        {
            inventoryItem.Add(item);
            currentWeight += item.weight;
            UpdateInventoryCanvas(item);
            

        }
    }

    void UpdateInventoryCanvas(Item item)
    {
        inventoryUI.UpdateUI(item);
    }
   
}
