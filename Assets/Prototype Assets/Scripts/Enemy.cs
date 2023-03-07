using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health;
    
    public Transform player;

    public float speed;
    public float timeBetweenAttacks;

    public int damage;

     public virtual void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }


    public void TakeDamage(int damageAmount){

        Health = Health - damageAmount;
        if(Health <=0){
            Debug.Log("dmg");
            Destroy(this.gameObject);
        }
    }
}
