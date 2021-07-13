using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class B_Inventory_Slot : MonoBehaviour
{

    public int index;
    public bool isEmpty = true;
    Item item;
    public TextMeshProUGUI itemText;
 

    public void AddItem(GameObject item,int i)
    {
        index = i;
        itemText.text = item.name;
        isEmpty = false;
    }

    public void RemoveItem()
    {
        Destroy(gameObject);
    }
}
