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
    TextMeshProUGUI itemText;
    private void Start()
    {
        itemText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void AddItem()
    {
       
    }

    public void RemoveItem()
    {
    }
}
