using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankPickup : MonoBehaviour
{   
    int plankAmount = 1;

   

    private void OnTriggerEnter2D(Collider2D other) {


        if( FindObjectOfType<BuildBarricade>().planks ==3){
            Debug.Log("Inventory full"); // Dodat UI za prikaz da je invetory full
        }else{

        if(other.gameObject.tag=="Player"){
            FindObjectOfType<Player>().PickupItem();
            Debug.Log("planks pickedup");
            FindObjectOfType<BuildBarricade>().IncreasePlanks(plankAmount);
            Destroy(gameObject);
        }
        }

      
    }
}
