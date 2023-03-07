using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBoxTest : MonoBehaviour
{
   
    public int Health;
    public GameObject weapon;


    public void DestroyBox(int dmg){

        Debug.Log("dmgbox");
        Health--;
        if(Health ==0){
            Debug.Log("LootBox");
            Instantiate(weapon,transform.position, transform.rotation);
            Destroy(this.gameObject);
        }

    }





}
