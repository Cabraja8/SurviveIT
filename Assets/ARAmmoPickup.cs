using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARAmmoPickup : MonoBehaviour
{

    int BulletAmount=20;
   
    

   private void OnTriggerEnter2D(Collider2D other) {
    
    if(other.gameObject.tag=="Player"){

        FindObjectOfType<Player>().PickupItem();
        Destroy(gameObject);
        FindObjectOfType<WeaponAmmoDisplay>().IncreaseBullets(BulletAmount);
    }
   }
}
