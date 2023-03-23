using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    public int health;

   public void TakeDamage(int damageAmount){
        
        health = health - damageAmount;
       
        if(health <=0){
            Destroy(this.gameObject);
            GameOver();
        }
    }

       public void GameOver(){
            Debug.Log("Game Over");
        }
}
