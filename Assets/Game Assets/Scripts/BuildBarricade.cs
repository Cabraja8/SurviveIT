using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BuildBarricade : MonoBehaviour
{   
    

   [SerializeField] TextMeshProUGUI displayPlanks;

    
    void Awake() {
        
        UpdateDisplay();
    }
     public void UpdateDisplay(){
        displayPlanks.text = FindObjectOfType<Player>().planks.ToString();
     
    }




}
