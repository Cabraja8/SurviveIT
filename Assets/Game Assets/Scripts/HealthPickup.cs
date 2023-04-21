using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthPickup : MonoBehaviour
{

    public int healthAmount;

    public TMP_Text healthdisplay;
    public int DestoryDelay=10;

    private void Start() {
        healthdisplay = FindObjectOfType<DisableText>().already100;
        healthdisplay.enabled = false;
        
      StartCoroutine(DestoryPickup());
    }
    

    IEnumerator DestoryPickup(){
        yield return new WaitForSeconds(DestoryDelay);
        GameObject ObjToRemove=gameObject;

        Destroy(ObjToRemove);
    }
    

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Player"){
            if(FindObjectOfType<Player>().health==100){
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
