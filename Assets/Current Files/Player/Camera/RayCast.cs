using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class RayCast : MonoBehaviour
{
    
    RaycastHit hit;

    [SerializeField] Canvas ItemCanvas;
    [SerializeField] TextMeshProUGUI obj;
    float raylength = 2f;
   
    void Awake(){
        disableUI();
    }

    void disableUI(){
       ItemCanvas.enabled = false;
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
        obj.text = hit.transform.name +"    " + hit.transform.GetComponent<ItemType>().item.weight.ToString();
        CheckforInput(hit.transform.gameObject);
    }

    void CheckforInput(GameObject item)
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Added item in inventory");
            GetComponentInParent<PlayerInventory>().AddItem(item);
            item.transform.localScale = new Vector3(0, 0, 0);
            //Destroy(item);
            
        }
    }

    
}

