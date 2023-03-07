using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{

    public Weapon WeaponToEquip;

    private void OnTriggerEnter2D(Collider2D other) {
      
        if(other.gameObject.tag=="Player"){
            Debug.Log("weapon picked up");
            other.GetComponent<Player>().ChangeWeapon(WeaponToEquip);
            Destroy(gameObject);
        }
    }
    
}
