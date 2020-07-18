using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class RayCast : MonoBehaviour
{

    RaycastHit hit;

    [SerializeField] Canvas ItemCanvas;
    [SerializeField] TextMeshProUGUI objName;
    [SerializeField] TextMeshProUGUI objWeight;
   
    void Awake(){
        disableUI();
    }

    void disableUI(){
       ItemCanvas.enabled = false;

    }
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        ProcessRaycast();
    }

    private void ProcessRaycast()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
        {
          if( hit.transform.GetComponent<ItemType>() != null ){
              updateUI(hit);
          }   
          else{
              disableUI();
          } 
        }
    }   

    void updateUI(RaycastHit hit){      
        ItemCanvas.enabled = true;
        objWeight.text = hit.transform.GetComponent<ItemType>().item.weight.ToString();
        objName.text = hit.transform.name;
    }

    
}

