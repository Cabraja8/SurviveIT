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

    public Animator deathAnim;

     public virtual void Start() {
       Target = GameObject.FindGameObjectWithTag("Zone").transform;
       deathAnim= GetComponent<Animator>();
        
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
             if(name == "Shadow Monster" || name=="Brute Monster"){
            FindObjectOfType<MeleeMonster>().speed=0;
            FindObjectOfType<MeleeMonster>().MonsterGrowl();
            FindObjectOfType<MeleeMonster>().UpdateDisplay();
            damage = 0;
            deathAnim.SetBool("death",true);
             }
              else if(name=="Bat Monster"){
                
                FindObjectOfType<RangedMonster>().Death();
              }
        }

    }
      

        public void Death(){
            Debug.Log("dmg");
            Destroy(this.gameObject);

        }
    public void ChangeTarget(){
        Target =  GameObject.FindGameObjectWithTag("Player").transform;
    }


     
}
