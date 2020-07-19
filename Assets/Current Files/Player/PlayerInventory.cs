using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerInventory : MonoBehaviour
{
    public List<Item> inventoryItem = new List<Item>();

    public float Maxweight = 200f;
    public float currentWeight = 0f;

    
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AddItem(Item item)
    {
        if(currentWeight + item.weight <= Maxweight)
        {
            inventoryItem.Add(item);
            currentWeight += item.weight;
        }
    }

   
}
