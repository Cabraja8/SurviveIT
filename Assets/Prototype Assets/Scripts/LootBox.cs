using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBox : MonoBehaviour
{
   
    
    public GameObject Drop;
    public GameObject spawnPoint;

    public AudioSource audiosource;

    public AudioClip BreakSound;


    

    public void DestroyBox(){
            audiosource.PlayOneShot(BreakSound);
            Invoke("DeleteBox",.3f);
            
    }

    public void DeleteBox(){
            Instantiate(Drop,spawnPoint.transform.position, spawnPoint.transform.rotation);
            Destroy(this.gameObject);
            Debug.Log("LootBox");

    }

 

   





}
