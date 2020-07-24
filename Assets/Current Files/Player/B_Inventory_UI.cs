using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityScript.Scripting.Pipeline;

public class B_Inventory_UI : MonoBehaviour
{
    public Transform ItemsParent;
    B_Inventory_Slot[] slots;

    public B_Inventory_Slot[] inventorySlot;
    public B_Inventory_Slot iSlot;
    float startPosX = -250f,startposY = 300f,mulitplier = 40f;
    public int itemsCount = 0;

    private void Start()
    {
        inventorySlot = ItemsParent.GetComponentsInChildren<B_Inventory_Slot>();
    }

    public void UpdateUI(GameObject playerItems)
    {
        /*   slots = ItemsParent.GetComponentsInChildren<B_Inventory_Slot>();
           itemsCount++;
           GameObject newslot = Instantiate(inventorySlot) as GameObject;
           newslot.transform.localScale = new Vector3(1, 1, 1);
           newslot.GetComponent<RectTransform>().position = new Vector2(startPosX,startposY - itemsCount*40f);


           newslot.transform.SetParent(ItemsParent);
           for(int i = 0; i < slots.Length; i++)
           {
               if (slots[i].isEmpty)
               {
                   slots[i].GetComponentInChildren<TextMeshProUGUI>().text = item.name;
                   slots[i].isEmpty = false;
                   return;

               }
           }
        */
        itemsCount = playerItems.transform.childCount;
        for(int i = 0; i < inventorySlot.Length; i++)
        {
            if (inventorySlot[i].isEmpty)
            {
                inventorySlot[i].AddItem(playerItems);
            }
        }
    }

    public void RemoveItem()
    {
       
    }
}
