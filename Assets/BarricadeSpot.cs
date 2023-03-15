using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarricadeSpot : MonoBehaviour
{   

    public bool InRange = false;
    public Transform player;
    float distance = Mathf.Infinity;
    float playerDistance = 4f;

    public GameObject NorthBarricade;
    public GameObject WestBarricade;
    public GameObject EastBarricade;
    public GameObject SouthBarricade;

    public string DirectionName;

    public bool IsBuiltNorth;
    public bool IsBuiltWest;
    public bool IsBuiltEast;
    public bool IsBuiltSouth;

    public bool Hovering =false;
    
    void OnMouseEnter() {

        if(InRange){

        
        DirectionName = gameObject.name;
        }
        if(DirectionName == null){
            Hovering = false;
        }else{
            Hovering=true;
        }
        
   }

   private void Start() {
   
    NorthBarricade.SetActive(false);
     WestBarricade.SetActive(false);
     EastBarricade.SetActive(false);
     SouthBarricade.SetActive(false);
   }

   private void Update() {

    InputForBuilding();



    distance = Vector2.Distance(player.position,transform.position);

    if (distance  <= playerDistance ){

        InRange= true;
        
    }

   if(distance  >= playerDistance ){
            
           InRange=false;
           
        }
   }

   void InputForBuilding(){
       
           
            if(Input.GetKeyDown(KeyCode.F) && InRange &&Hovering){
                if(FindObjectOfType<BuildBarricade>().planks==3){
                     if(DirectionName == "NorthSpot" && IsBuiltNorth){
                
                     Debug.Log("you already built this barricade");
                        }else if(DirectionName == "WestSpot" && IsBuiltWest){
                            Debug.Log("you already built this barricade");
                        }else if(DirectionName == "EastSpot" && IsBuiltEast){
                            Debug.Log("you already built this barricade");
                        }else if(DirectionName == "SouthSpot" && IsBuiltSouth){
                            Debug.Log("you already built this barricade");
                        }
                        else{

                    FindObjectOfType<BuildBarricade>().planks=1;
                    BuildBarricade();
                        }
                }
                if(FindObjectOfType<BuildBarricade>().planks==2){
                   FindObjectOfType<BuildBarricade>().planks=0;
                   BuildBarricade();
                    
                }
                 if(FindObjectOfType<BuildBarricade>().planks==1){
                  
                    FindObjectOfType<BuildBarricade>().planks=1;
                    Debug.Log("you need more planks");
                    
                }
                 if(FindObjectOfType<BuildBarricade>().planks==0){
                   
                    FindObjectOfType<BuildBarricade>().planks=0;
                    Debug.Log("there's no more planks");
                    
                }
            }
        
        


    }

   public void BuildBarricade(){
       

        if(DirectionName == "NorthSpot" && !IsBuiltNorth){
            IsBuiltNorth = true;
            NorthBarricade.SetActive(true);
          
        }
         if(DirectionName == "WestSpot" && !IsBuiltWest){
            IsBuiltWest = true;
            WestBarricade.SetActive(true);
            
        }
         if(DirectionName == "EastSpot" && !IsBuiltEast){
            IsBuiltEast = true;
            EastBarricade.SetActive(true);
            
        }
         if(DirectionName == "SouthSpot" && !IsBuiltSouth){
            IsBuiltSouth = true;
            SouthBarricade.SetActive(true);
           
        }

        
   }
}
