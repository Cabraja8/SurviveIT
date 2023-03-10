using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    
    
    public Transform TargetP;
    public Vector2 targetPosition;
    public float lifeTime;

    public int damageAmount;

    public float speed;


    private void Start() {
        TargetP = FindObjectOfType<Enemy>().Target;
        targetPosition = TargetP.transform.position;
        Destroy(gameObject,lifeTime);
    }

     void Update() {
      if (Vector2.Distance(transform.position,targetPosition)>.1f){
        transform.position=Vector2.MoveTowards(transform.position,targetPosition,speed*Time.deltaTime);
      } else{
        Destroy(gameObject);
      }  
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            FindObjectOfType<Player>().TakeDamage(damageAmount);
            Destroy(gameObject);
        }
        if(other.tag=="Zone"){
            FindObjectOfType<Zone>().TakeDamage(damageAmount);
        }
         if(other.tag=="Wall"){
            Destroy(gameObject);
        }
    }
}
