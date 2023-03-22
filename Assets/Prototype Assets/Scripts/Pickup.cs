using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{       

  
      private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="Player"){
            FindObjectOfType<Player>().PickupItem();
            Debug.Log("picked up");
            Destroy(gameObject);
            FindObjectOfType<WeaponAmmoDisplay>().IncreaseBullets(10);
        }
    }
}
