using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{   

     public SpriteRenderer rend;

     public Animator anim;

    float AttackTime;

     public float timeBetweenAttacks;

      void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        
        }
 
    void Update()
    {
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
    if(Input.GetMouseButton(0)){
        if(Time.time >= AttackTime){
        Attack();
        }
    }
    }

    void Attack(){
        anim.SetTrigger("Attack");
        Debug.Log("attack");
        AttackTime = Time.time + timeBetweenAttacks;
    }

    
}
