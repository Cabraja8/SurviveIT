using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBarricade : MonoBehaviour
{   
    

   

    
   public int planks;



    public void IncreasePlanks(int plankAmount){
        planks = planks + plankAmount;
        

        if(planks >3){
            planks =3;
        }
    }
}
