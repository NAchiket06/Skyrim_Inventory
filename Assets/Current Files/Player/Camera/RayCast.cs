using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class RayCast : MonoBehaviour
{
    
    RaycastHit hit;

    [SerializeField] Canvas ItemCanvas;
    [SerializeField] TextMeshProUGUI Name,weight,value;
    float raylength = 2f;
   
    void Awake(){
        disableUI();
    }

    void Update()
    {
        ProcessRaycast();
    }

    private void ProcessRaycast()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, raylength))
        {
          if( hit.transform.GetComponent<ItemType>() != null ){
              updateUI(hit);
                // Changed the raylength so that when player removes focus from the object, the ray is long enough to return a null instead of returning nothing
              raylength = 100f;
            }   
          else {
              disableUI();
                raylength = 2f;

          } 
        }
    }   

    void updateUI(RaycastHit hit){      
        ItemCanvas.enabled = true;
        //obj.text = hit.transform.name +"    " + hit.transform.GetComponent<ItemType>().item.weight.ToString();
        Name.text = hit.transform.name;
        weight.text = hit.transform.GetComponent<ItemType>().item.weight.ToString();
        value.text = hit.transform.GetComponent<ItemType>().item.value.ToString();
        CheckforInput(hit.transform.gameObject);
    }

    void CheckforInput(GameObject item)
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Added "+item.name +" in inventory");
            GetComponentInParent<PlayerInventory>().AddItem(item);
        }
    }
    void disableUI()
    {
        ItemCanvas.enabled = false;
    }


}

