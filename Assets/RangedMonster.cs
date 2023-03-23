using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedMonster : Enemy
{
   public float stopDistance;

    private float attackTime;

    public Animator anim;

    public Transform shotPoint;
    public GameObject enemybullet;
     float distance = Mathf.Infinity;
    float distanceToPlayer = 4f;

     public AudioSource audiosource;
   public AudioClip Growl;

   public GameObject death;

   public override void Start() {
    base.Start();
        anim = GetComponent<Animator>();
    }


    private void Update() {

        distance = Vector2.Distance(Player.position,transform.position);

         if (distance  <= distanceToPlayer ){

        FindObjectOfType<Enemy>().ChangeTarget();
         }

        if(Target != null){
        if(Vector2.Distance(transform.position,Target.position)>stopDistance){
            transform.position = Vector2.MoveTowards(transform.position,Target.position,speed*Time.deltaTime);
        }
        if(Time.time >=attackTime){
            attackTime = Time.time + timeBetweenAttacks;
            anim.SetTrigger("attack");
        }
        
        }
    }
     public void DamageTaken(){
        anim.SetTrigger("damaged");
    }
    public void MonsterGrowl(){
        audiosource.PlayOneShot(Growl);
        Debug.Log("growl");
    }
    
    public void Death(){
        Debug.Log("dead");
        Instantiate(death,transform.position,transform.rotation);
        MonsterGrowl();
        Destroy(this.gameObject);
    }

  

   
    public void RangedAttack(){
         Vector2 direction = Target.position - shotPoint.position;

        float angle= Mathf.Atan2(direction.y,direction.x)* Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle -90, Vector3.forward);

        shotPoint.rotation = rotation;

        if(!audiosource.isPlaying){

       MonsterGrowl();
        }

        Instantiate(enemybullet,shotPoint.position,shotPoint.rotation);


    }
}
