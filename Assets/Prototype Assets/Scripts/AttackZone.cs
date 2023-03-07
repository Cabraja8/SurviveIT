using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
   public int Health;
    
    public Transform zone;

    public Transform Player;

    public float speed;
    public float timeBetweenAttacks;

    public int damage;

     public void Start() {
        zone = GameObject.FindGameObjectWithTag("Zone").transform;
        
    }
     public float stopDistance;
  
   private float attackTime;

   public float attackSpeed;
    

    // Update is called once per frame
    void Update()
    {
        if(zone!=null){

            if(Vector2.Distance(transform.position,zone.position)> stopDistance){
                transform.position = Vector2.MoveTowards(transform.position,zone.position, speed*Time.deltaTime);
            }else{
                if(Time.time >=attackTime){
                    StartCoroutine(Attack());
                    attackTime = Time.time + timeBetweenAttacks;
                }
            }
        }
        
    }
    IEnumerator Attack(){
        Debug.Log(zone.tag);
        if(zone.tag == "Zone"){
        zone.GetComponent<Zone>().TakeDamage(damage);
        }else if(zone.tag =="Player"){
        Player.GetComponent<Player>().TakeDamage(damage);
        }
        

        Vector2 originalPosition = transform.position;
        Vector2 targetPosition = zone.position;
        float percent=0;

        while(percent<=1){
            percent +=Time.deltaTime * attackSpeed;
            float formula= (-Mathf.Pow(percent,2)+percent)*4;
            transform.position = Vector2.Lerp(originalPosition,targetPosition, formula);
            yield return null;
        }

    }
    public void TakeDamage(int damageAmount){

        Health = Health - damageAmount;
        if(Health <=0){
            Debug.Log("dmg");
            Destroy(this.gameObject);
        }
    }

   public void ChangeTarget(){
        zone =  GameObject.FindGameObjectWithTag("Player").transform;
    }

     


   
}
