using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityScript.Scripting.Pipeline;

public class B_Inventory_UI : MonoBehaviour
{
    

    public B_Inventory_Slot[] slots; // list of all the ui panels in itemsParent
    public GameObject itemsParent; // parent gameobject of the ui panel

    public GameObject panel; // ui panel to be instantiated
    public int itemCount;


    public void UpdateUI(List<GameObject> playerItems) // list of all the player items
    {
            getSlots();
            for (int i = 0; i < slots.Length; i++)
            {
                slots[i].AddItem(playerItems[i]);
            }
        
    }

    public void RemoveItem(List<GameObject> playerItems)
    {
        Debug.Log("playerItems has count " + playerItems.Count);
        itemCount = playerItems.Count;
        Destroy(slots[itemCount].gameObject);
        if(playerItems.Count == 0)
        {
            Debug.Log("No items in inventory");
           
            return;
        }
        else UpdateUI(playerItems);
        
        
    }

    public void AddItem(List<GameObject> playerItems)
    {
        GameObject panel = InstatiatePanel();
        UpdateUI(playerItems);
        itemCount = playerItems.Count;
    }
    private GameObject InstatiatePanel()
    {
        GameObject Panel = Instantiate(panel) as GameObject;
        Panel.transform.SetParent(itemsParent.transform);
        Panel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, - itemCount * 50);
        Panel.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        return Panel;
    }

    void getSlots() {
        slots = itemsParent.GetComponentsInChildren<B_Inventory_Slot>();
    }

}
