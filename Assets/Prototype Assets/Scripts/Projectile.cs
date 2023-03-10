using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;

    public GameObject explosion;

    public int damage;
   

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

     
         if(other.tag=="Enemy"){
            other.GetComponent<Enemy>().TakeDamage(damage);
            FindObjectOfType<Enemy>().ChangeTarget();
            DestroyProjectile();
            Kill();
        }
         if(other.tag=="LootBox"){
            other.GetComponent<LootBox>().DestroyBox();
            DestroyProjectile();
          
        }
         if(other.tag=="Wall"){
            DestroyProjectile();
       
          
        }

        
   }

   public void DestroyProjectile(){
        Instantiate(explosion,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }


    void Kill(){
         Destroy(gameObject,lifeTime);
    }
}
