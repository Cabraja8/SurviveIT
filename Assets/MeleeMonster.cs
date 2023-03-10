using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeMonster : Enemy
{
  public float stopDistance;
  
   private float attackTime;

   public float attackSpeed;
    

    // Update is called once per frame
    void Update()
    {
        if(Target!=null){

            if(Vector2.Distance(transform.position,Target.position)> stopDistance){
                transform.position = Vector2.MoveTowards(transform.position,Target.position, speed*Time.deltaTime);
            }else{
                if(Time.time >=attackTime){
                    StartCoroutine(Attack());
                    attackTime = Time.time + timeBetweenAttacks;
                }
            }
        }
        
    }

   

    IEnumerator Attack(){
        if(Target.tag=="Player"){
        Target.GetComponent<Player>().TakeDamage(damage);
        }
        if(Target.tag=="Zone"){
        Target.GetComponent<Zone>().TakeDamage(damage);
        }

        Vector2 originalPosition = transform.position;
        Vector2 targetPosition = Target.position;
        float percent=0;

        while(percent<=1){
            percent +=Time.deltaTime * attackSpeed;
            float formula= (-Mathf.Pow(percent,2)+percent)*4;
            transform.position = Vector2.Lerp(originalPosition,targetPosition, formula);
            yield return null;
        }

    }
}
