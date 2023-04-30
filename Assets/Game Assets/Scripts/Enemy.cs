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
       Target = FindObjectOfType<Zone>().transform;
       Player = FindObjectOfType<Player>().transform;
       deathAnim= GetComponent<Animator>();
        
    }

   


    public void TakeDamage(int damageAmount, Collider2D enemy){

        Health = Health - damageAmount;

        if(name == "Shadow Monster(Clone)" || name=="Brute Monster(Clone)"){
       
         if(Health <=0){
            enemy.GetComponent<MeleeMonster>().MonsterGrowl();
            enemy.GetComponent<MeleeMonster>().UpdateDisplay();
            enemy.GetComponent<Enemy>().speed=0;
            enemy.GetComponent<Enemy>().damage=0;
            deathAnim.SetBool("death",true);
         }
        enemy.GetComponent<MeleeMonster>().DamageTaken();
        }
        if(name=="Bat Monster(Clone)"){
          
            if(Health<=0){
                 enemy.GetComponent<RangedMonster>().Death();
                enemy.GetComponent<Enemy>().speed=0;
            }
            enemy.GetComponent<RangedMonster>().DamageTaken();

            
        }
       
    }
      

        public void Death(){
            Debug.Log("dmg");
            Destroy(this.gameObject);

        }
    public void ChangeTarget(){
        Target = Player;
    }


     
}
