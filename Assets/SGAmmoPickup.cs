using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGAmmoPickup : MonoBehaviour
{
     int shellAmount=10;
    

   private void OnTriggerEnter2D(Collider2D other) {
    
    if(other.gameObject.tag=="Player"){
        Destroy(gameObject);
        FindObjectOfType<WeaponAmmoDisplay>().IncreaseShells(shellAmount);
    }
   }
}
