using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public float speed;

   public Rigidbody2D rb;
   private Animator anim;

   public int health;
    private Vector2 MoveAmount;

//    private Inventory Inventory;

//    public HealthBar healthBar;




     void Start() {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        // Inventory = new Inventory();
    }


     void Update() {
        Vector2 MoveInput = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        MoveAmount = MoveInput.normalized * speed;

        if (MoveInput != Vector2.zero){
            anim.SetBool("IsRunning",true);
        }
        else{
            anim.SetBool("IsRunning",false);
            
        }

    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + MoveAmount * Time.fixedDeltaTime);
    }
    public void TakeDamage(int damageAmount){

        health = health - damageAmount;
        // healthBar.SetHealth(health);
        if(health <=0){
            Destroy(this.gameObject);
        }
    }



    public void ChangeWeapon(Weapon WeaponToEquip){
      

      //SetActive weapon umjesto instantiate-a

        Debug.Log("Weapon changed");
    
        Instantiate(WeaponToEquip,transform.position,transform.rotation,transform);
    }
    
    // public void RecoverHealth(int healthAmount){
    //     health = health + healthAmount;

    //     if(health > 100){
    //         health = 100;
    //     }

    // }
}
