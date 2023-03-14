using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBarricade : MonoBehaviour
{   
    float distance = Mathf.Infinity;
    float BarricadeSpotDistance = 4f;
    public Transform barricadeSpot;


    
   public int planks;

   
   

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    void CheckDistance(){
        barricadeSpot =null;
        barricadeSpot = FindObjectOfType<BarricadeSpot>().transform;
         distance = Vector2.Distance(barricadeSpot.position,transform.position);

        if (distance  <= BarricadeSpotDistance ){
            barricadeSpot =null;
            barricadeSpot = FindObjectOfType<BarricadeSpot>().transform;
            if(Input.GetKeyDown(KeyCode.F)){
                if(planks>=2){
                    planks--;
                   

                   //build barricade
                }
                else if(planks<2){
                    Debug.Log("you need more planks");
                }
                else if(planks==0){
                    Debug.Log("there's no more planks");
                }
            }
        }
        if(distance  >= BarricadeSpotDistance ){
            barricadeSpot =null;
            barricadeSpot = FindObjectOfType<BarricadeSpot>().transform;
             Debug.Log("Player is not close");
        }


    }

    public void BuildTheBarricade(){

    }

    public void IncreasePlanks(int plankAmount){
        planks = planks + plankAmount;


        if(planks >3){
            planks =3;
        }
    }
}
