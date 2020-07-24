using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class B_Inventory_Slot : MonoBehaviour
{
    public Transform spawnPos;

    public bool isEmpty = true;
    Item item;
    public TextMeshProUGUI itemText;
    private void Start()
    {
       
    }

    public void AddItem(GameObject item)
    {
        itemText.text = item.name;
        isEmpty = false;
    }

    public void RemoveItem()
    {
    }
}
