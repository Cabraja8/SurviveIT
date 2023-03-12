using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBox : MonoBehaviour
{
   
    
    public GameObject Drop;
    public GameObject spawnPoint;


    

    public void DestroyBox(){

            Instantiate(Drop,spawnPoint.transform.position, spawnPoint.transform.rotation);
            Destroy(this.gameObject);
            Debug.Log("LootBox");
            
            
     
            
    }

    public void DeleteDrop(){
        Destroy(this.gameObject);
        
        
    }

   





}
