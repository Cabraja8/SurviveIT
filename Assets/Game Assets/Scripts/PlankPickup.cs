using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlankPickup : MonoBehaviour
{   
    int plankAmount = 1;
    public TMP_Text planksfull;
    public int DestoryDelay=10;

    private void Start() {
        planksfull = FindObjectOfType<DisableText>().already3;
        planksfull.enabled = false;
    StartCoroutine(DestoryPickup());
    }
    

    IEnumerator DestoryPickup(){
        yield return new WaitForSeconds(DestoryDelay);
        GameObject ObjToRemove=gameObject;

        Destroy(ObjToRemove);
    }

   

    private void OnTriggerEnter2D(Collider2D other) {


        if( FindObjectOfType<BuildBarricade>().planks ==3){
            Debug.Log("Inventory full"); 
            planksfull.enabled = true;
            Invoke("disabletext",1.5f);
        }else{

        if(other.gameObject.tag=="Player"){
            FindObjectOfType<Player>().PickupItem();
            Debug.Log("planks pickedup");
            FindObjectOfType<BuildBarricade>().IncreasePlanks(plankAmount);
            FindObjectOfType<BuildBarricade>().UpdateDisplay();
            Destroy(gameObject);
        }
        }

      
    }

   void disabletext(){
    planksfull.enabled = false;
    }
}
