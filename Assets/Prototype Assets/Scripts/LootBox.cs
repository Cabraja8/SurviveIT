using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBox : MonoBehaviour
{
   
    
    public Weapon weapon;
    public GameObject spawnPoint;


    

    public void DestroyBox(){

      
       
        
            Destroy(this.gameObject);
            Debug.Log("LootBox");
            
            weapon.GetComponent<Weapon>().enabled=false;
            weapon.GetComponent<WeaponPickup>().enabled=true;
            
            Instantiate(weapon,spawnPoint.transform.position, spawnPoint.transform.rotation);
     

    }





}
