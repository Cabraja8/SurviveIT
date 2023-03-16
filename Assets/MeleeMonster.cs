using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeMonster : Enemy
{
  public float stopDistance;
  
   private float attackTime;
   float distance = Mathf.Infinity;
    float distanceToPlayer = 4f;

   public float attackSpeed;
   public Animator anim;

   private void Start() {
    anim = GetComponent<Animator>();
   }
    

    // Update is called once per frame
    void Update()
    {   
        distance = Vector2.Distance(Player.position,transform.position);

         if (distance  <= distanceToPlayer ){

        FindObjectOfType<Enemy>().ChangeTarget();
         }


        if(Target!=null){

            if(Vector2.Distance(transform.position,Target.position)> stopDistance){
                transform.position = Vector2.MoveTowards(transform.position,Target.position, speed*Time.deltaTime);
            }else{
                if(Time.time >=attackTime){
                    anim.SetTrigger("attack");
                    StartCoroutine(Attack());
                    attackTime = Time.time + timeBetweenAttacks;
                }
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.name== "NorthBarricade" || other.gameObject.name== "WestBarricade" || other.gameObject.name== "EastBarricade" || other.gameObject.name== "SouthBarricade"){
        Debug.Log(other.gameObject.name);
       
       
        anim.SetTrigger("attack");
   
        StartCoroutine(FindObjectOfType<BarricadeSpot>().TakeDamage(other.gameObject.name));
        
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
