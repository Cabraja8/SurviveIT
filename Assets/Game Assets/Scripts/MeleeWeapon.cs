using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{   

     public SpriteRenderer rend;

     public Animator anim;

    float AttackTime;

     public float timeBetweenAttacks;

     public int damage;

     public Transform attackPoint;

     public float attackRange = 0.5f;

     public LayerMask enemyLayers;

     public AudioSource audiosource;

    public AudioClip AttackSound;

      void Start()
    {
        
        
        }
 
    void Update()
    {   
        if(!PauseMenu.GameIsPaused){
            WeaponControl();
        }

    if(Input.GetMouseButton(0) && !PauseMenu.GameIsPaused){
        if(Time.time >= AttackTime){
        Attack();
        }
    }
    }

    void WeaponControl(){
         Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float angle= Mathf.Atan2(direction.y,direction.x)* Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle -90f, Vector3.forward);

        transform.rotation = rotation;
          if(angle >=90 || angle<= -90){
            rend.flipX = true;
         
        }
        else{
            rend.flipX = false;
           

        }

    }

    void Attack(){

        Debug.Log(gameObject.name);

        audiosource.PlayOneShot(AttackSound);
        if(gameObject.name=="Knife"){
        anim.SetTrigger("Knife");
        }
         if(gameObject.name=="crowbar"){
        anim.SetTrigger("Attack");
        }

        Debug.Log("attack");
        AttackTime = Time.time + timeBetweenAttacks;


       Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);

       foreach (Collider2D enemy in hitEnemies)
       {
        Debug.Log("we hit" + enemy.name);


         if(enemy.name.Contains("Shadow Monster")){ 
        enemy.GetComponent<Enemy>().TakeDamage(damage,enemy);
         }
         if(enemy.name.Contains("Bat Monster")){ 
        enemy.GetComponent<Enemy>().TakeDamage(damage,enemy);
         }
           if(enemy.name.Contains("Brute Monster")){ 
        enemy.GetComponent<Enemy>().TakeDamage(damage,enemy);
         }
         
        if(enemy.name.Contains("LootBox")){ 
        enemy.GetComponent<LootBox>().DestroyBox();
        }
          
       
       }
    }

    private void OnDrawGizmosSelected() {
        if(attackPoint ==null){
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }

    
}
