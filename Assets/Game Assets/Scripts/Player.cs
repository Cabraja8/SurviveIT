using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
   public float speed;

   public Rigidbody2D rb;
   private Animator anim;

   public int health;
    private Vector2 MoveAmount;

    public AudioSource audiosource;

    public AudioClip pickupsound;


   public HealthBar healthBar;

    public float planks=3f;

   private void Awake() {
    Time.timeScale =1f;
   }




     void Start() {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
      
    }
    public void IncreasePlanks(float plankAmount){
        planks = planks + plankAmount;
        FindObjectOfType<BuildBarricade>().UpdateDisplay();

        if(planks >3f){
            planks =3f;
        }
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

        healthBar.SetHealth(health);
     
        if(health <=0){
            healthBar.SetHealth(health);
            Destroy(this.gameObject);
            FindObjectOfType<Zone>().GameOver();
                    }
    }


    public void PickupItem(){
        audiosource.PlayOneShot(pickupsound);
    }

    
    public void RecoverHealth(int healthAmount){
        health = health + healthAmount;
        if(health > 500){
            health = 500;
        }
        healthBar.SetHealth(health);

    }
}
