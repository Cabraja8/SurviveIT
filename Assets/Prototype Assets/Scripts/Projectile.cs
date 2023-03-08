using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;

    public GameObject explosion;

    public int damage;
    public int dmg;

    void Start()
    {   
        Invoke("DestroyProjectile",lifeTime);
        Destroy(gameObject,lifeTime);
    }


    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
   private void OnTriggerEnter2D(Collider2D other) {

        // if(other.tag=="Enemy"){
        //     other.GetComponent<Enemy>().TakeDamage(damage);
        //     Kill();
        // }
         if(other.tag=="Enemy"){
            other.GetComponent<Enemy>().TakeDamage(damage);
            FindObjectOfType<Enemy>().ChangeTarget();
            Kill();
        }
         if(other.tag=="LootBox"){
            other.GetComponent<LootBoxTest>().DestroyBox(dmg);
          
        }
         if(other.tag=="Wall"){
            DestroyProjectile();
       
          
        }

        
   }

    void DestroyProjectile(){
        Instantiate(explosion,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }


    void Kill(){
         Destroy(gameObject,lifeTime);
    }
}
