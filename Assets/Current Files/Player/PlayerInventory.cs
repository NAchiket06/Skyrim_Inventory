using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerInventory : MonoBehaviour
{
    public B_Inventory_UI inventoryUI; // handles inventory UI
    public Canvas inventoryCanvas;
    public List<GameObject> inventoryItem = new List<GameObject>(); // list that holds the items
    public GameObject playerItems; // parent object that holds the player items
    public Transform worldItems;


    public float Maxweight = 200f;
    public float currentWeight = 0f;

    [SerializeField] bool isInventoryActive;

    public Transform SpawnPos; // spawn position of instantiated objects

    private void Start()
    {
        inventoryCanvas.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isInventoryActive = !isInventoryActive;
           
            inventoryCanvas.enabled = !inventoryCanvas.enabled;
        }
       
        if (isInventoryActive)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            inventoryUI.enabled = true;
            if (Input.GetKeyDown(KeyCode.T) && inventoryItem.Count > 0)
            {
                RemoveItem();
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
    }

    private void RemoveItem()
    {
        GameObject item = inventoryItem[0];
        Debug.Log("Removed " + inventoryItem[0].name + "from List");
        SpawnItemInWorld(item);
        currentWeight -= item.GetComponent<ItemType>().item.weight;
        inventoryItem.Remove(item); // removes item from list
        inventoryUI.RemoveItem(inventoryItem); // removes item from ui
        return;
    }

    private void SpawnItemInWorld(GameObject item)
    {
        item.transform.SetParent(worldItems);
        item.SetActive(true);
        item.transform.localScale = item.GetComponent<ItemType>().item.scale;
        item.transform.position = SpawnPos.position;
    }

    public bool AddItem(GameObject item)
    {

         float weight = item.GetComponent<ItemType>().item.weight;
        if (currentWeight + weight <= Maxweight)
        {
            currentWeight += weight;
            AddInInventory(item);
            return true;
        }
        else return false;    
    }

    private void AddInInventory(GameObject item)
    {
        item.transform.SetParent(playerItems.transform);
        inventoryItem.Add(item);
        inventoryUI.AddItem(inventoryItem);
        item.SetActive(false);
        
    }
        
   
   
}
