using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health;
    
    public Transform Target;
    public Transform Player;
    

    public float speed;
    public float timeBetweenAttacks;

    public int damage;

     public virtual void Start() {
       Target = GameObject.FindGameObjectWithTag("Zone").transform;
        
    }

   


    public void TakeDamage(int damageAmount){

        Health = Health - damageAmount;

        if(name == "Shadow Monster" || name=="Brute Monster"){
        FindObjectOfType<MeleeMonster>().DamageTaken();
        }
        if(name=="Bat Monster"){
            FindObjectOfType<RangedMonster>().DamageTaken();
        }
        if(Health <=0){
            Debug.Log("dmg");
            Destroy(this.gameObject);
        }
    }
    public void ChangeTarget(){
        Target =  GameObject.FindGameObjectWithTag("Player").transform;
    }


     private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="Player"){
           ChangeTarget();
        }
    }
}
