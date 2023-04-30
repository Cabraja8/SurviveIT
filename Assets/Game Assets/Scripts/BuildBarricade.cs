using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BuildBarricade : MonoBehaviour
{   
    

   [SerializeField] TextMeshProUGUI displayPlanks;

    
   public int planks;

    void Awake() {
        
        UpdateDisplay();
    }
     public void UpdateDisplay(){
        displayPlanks.text = planks.ToString();
     
    }



    public void IncreasePlanks(int plankAmount){
        planks = planks + plankAmount;
        UpdateDisplay();

        if(planks >3){
            planks =3;
        }
    }
}
