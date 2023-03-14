using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{

    public int healthAmount;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="Player"){
            Debug.Log("picked up health");
            Destroy(gameObject);
            FindObjectOfType<Player>().RecoverHealth(healthAmount);
        }
    }
}
