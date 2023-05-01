using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthPickup : MonoBehaviour
{

    public int healthAmount=500;

    public TMP_Text healthdisplay;
    public int DestroyDelay=10;

    private void Start() {
        healthdisplay = FindObjectOfType<DisableText>().already100;
        healthdisplay.enabled = false;
        
      StartCoroutine(DestoryPickup());
    }
    

    IEnumerator DestoryPickup(){
        yield return new WaitForSeconds(DestroyDelay);
        GameObject ObjToRemove=gameObject;

        Destroy(ObjToRemove);
    }
    

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Player"){
            if(FindObjectOfType<Player>().health==500){
                Debug.Log("Your health is full");
                healthdisplay.enabled = true;
                Invoke("disabletext",1.5f);
            }else{
                FindObjectOfType<Player>().PickupItem();
            Debug.Log("picked up health");
            Destroy(gameObject);
            FindObjectOfType<Player>().RecoverHealth(healthAmount);
            }
        }
    }


    void disabletext(){
        healthdisplay.enabled = false;
    }


}
