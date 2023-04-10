using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBox : MonoBehaviour
{
   
    
    
 
    public AudioSource audiosource;

    public AudioClip BreakSound;

    public GameObject[] Drop;


    

    public void DestroyBox(){
            audiosource.PlayOneShot(BreakSound);
            Invoke("DeleteBox",.3f);
            
    }

    public void DeleteBox(){
            int randomIndex = Random.Range(0, Drop.Length);
                GameObject randomObject = Drop[randomIndex];
                Instantiate(randomObject, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Debug.Log("LootBox");

    }

 

   





}
