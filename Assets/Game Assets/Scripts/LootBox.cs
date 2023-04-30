using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBox : MonoBehaviour
{
   
    
    
 
    public AudioSource audiosource;

    public AudioClip BreakSound;

    public GameObject[] Drop;


    private void Start() {
        audiosource = FindObjectOfType<Player>().GetComponent<AudioSource>();
    }
    

    public void DestroyBox(){
            audiosource.PlayOneShot(BreakSound);
            Invoke("DeleteBox",.3f);
            
    }

    public void DeleteBox(){
            int randomIndex = Random.Range(0, Drop.Length);
                GameObject randomObject = Drop[randomIndex];
                Instantiate(randomObject, transform.position, Quaternion.identity);

            GameObject remove = gameObject;
            Destroy(remove);
            Debug.Log("LootBox");

    }
    private LootBoxSpawner.LootBoxSpawnPoint spawnPoint;

    public void SetSpawnPoint(LootBoxSpawner.LootBoxSpawnPoint point)
    {
        spawnPoint = point;
    }

    private void OnDestroy()
    {
        if (spawnPoint != null)
        {
            spawnPoint.isOccupied = false;
        }
    }

 

   





}
