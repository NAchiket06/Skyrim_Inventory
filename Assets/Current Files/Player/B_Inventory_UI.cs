using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityScript.Scripting.Pipeline;

public class B_Inventory_UI : MonoBehaviour
{
    public Transform ItemsParent;
    B_Inventory_Slot[] slots;

     
    // Start is called before the first frame update
    void Start()
    {
        slots = ItemsParent.GetComponentsInChildren<B_Inventory_Slot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateUI(Item item)
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (slots[i].isEmpty)
            {
                slots[i].AddItem(item);
                return;
            }
        }
    }

    public void RemoveItem()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(slots[i].isEmpty == false)
            {
                slots[i].RemoveItem();
                return;
            }
        }
    }
}
