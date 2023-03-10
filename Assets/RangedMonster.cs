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

   public override void Start() {
    base.Start();
        anim = GetComponent<Animator>();
    }


    private void Update() {

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

    public void RangedAttack(){
         Vector2 direction = Target.position - shotPoint.position;

        float angle= Mathf.Atan2(direction.y,direction.x)* Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle -90, Vector3.forward);

        shotPoint.rotation = rotation;

        Instantiate(enemybullet,shotPoint.position,shotPoint.rotation);


    }
}
