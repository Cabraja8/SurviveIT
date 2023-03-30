using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public AudioSource audisource;

    public AudioClip BreakSound;
    public AudioClip BuildSound;
    
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

    if(!InRange || !Hovering){
        DirectionName = null;
    }

   


    distance = Vector2.Distance(player.position,transform.position);

    if (distance  <= playerDistance ){

        InRange= true;
        
    }

   if(distance  >= playerDistance ){
            
           InRange=false;
           
        }
   }

//    void OnMouseExit(){
//     Hovering = false;
//    }

   void InputForBuilding(){
       
           
            if(Input.GetKeyDown(KeyCode.F) && InRange && Hovering && DirectionName != "" ){
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
                    FindObjectOfType<BuildBarricade>().UpdateDisplay();
                    Invoke("BuildBarricade",0.5f);
                        }
                }
                if(FindObjectOfType<BuildBarricade>().planks==2){

                     if(DirectionName == "NorthSpot" && IsBuiltNorth && DirectionName != "" ){
                
                     Debug.Log("you already built this barricade");
                        }else if(DirectionName == "WestSpot" && IsBuiltWest){
                            Debug.Log("you already built this barricade");
                        }else if(DirectionName == "EastSpot" && IsBuiltEast){
                            Debug.Log("you already built this barricade");
                        }else if(DirectionName == "SouthSpot" && IsBuiltSouth){
                            Debug.Log("you already built this barricade");
                        }
                        else{
                   FindObjectOfType<BuildBarricade>().planks=0;
                   FindObjectOfType<BuildBarricade>().UpdateDisplay();
                  Invoke("BuildBarricade",0.5f);
                        }
                    
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
       
       audisource.PlayOneShot(BuildSound);

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


   public IEnumerator TakeDamage(string barricadeName){
   
    yield return new WaitForSeconds(2.0f);

    audisource.PlayOneShot(BreakSound);

    if(barricadeName == "NorthBarricade" ){
        IsBuiltNorth = false;
        NorthBarricade.SetActive(false);
     
        
    }
     if(barricadeName == "EastBarricade" ){
        IsBuiltEast = false;
        EastBarricade.SetActive(false);
        
        
    }
    if(barricadeName == "WestBarricade" ){
        IsBuiltWest = false;
        WestBarricade.SetActive(false);
       
        
    }
     if(barricadeName == "SouthBarricade" ){
        IsBuiltSouth = false;
        SouthBarricade.SetActive(false);
        
        
    }
   
     

   }
}
