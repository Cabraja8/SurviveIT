using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthPickup : MonoBehaviour
{

    public int healthAmount;

    public TMP_Text healthdisplay;

    private void Start() {
        healthdisplay.enabled = false;
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
