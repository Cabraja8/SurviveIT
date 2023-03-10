using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBox : MonoBehaviour
{
   
    
    public GameObject weapon;


    public void DestroyBox(){

        Debug.Log("dmgbox");
       
        
            Debug.Log("LootBox");
            Instantiate(weapon,transform.position, transform.rotation);
            Destroy(this.gameObject);
     

    }





}
