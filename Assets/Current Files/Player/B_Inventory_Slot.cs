using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B_Inventory_Slot : MonoBehaviour
{
    public bool isEmpty = true;
    Item item;
    Text itemText;
    private void Start()
    {
        itemText = GetComponentInChildren<Text>();
    }

    public void AddItem(Item newItem)
    {
        isEmpty = false;
        item = newItem;
        itemText.text = item.name; 
    }

    public void RemoveItem()
    {
        Instantiate(item.obj);
        isEmpty = true;
        item = null;
        itemText.text = null;
    }
}
