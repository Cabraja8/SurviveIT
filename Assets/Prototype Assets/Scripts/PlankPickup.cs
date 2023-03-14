using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankPickup : MonoBehaviour
{   
    int plankAmount = 1;

    private void OnCollisionEnter2D(Collision2D other) {


      
        if(other.gameObject.tag=="Player"){

            Debug.Log("planks pickedup");
            FindObjectOfType<BuildBarricade>().IncreasePlanks(plankAmount);
            Destroy(gameObject);
        }
    }
}
