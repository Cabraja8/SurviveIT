using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zone : MonoBehaviour
{
    public int health;
    public Slider slider;
    public GameOverScreen GameOverScreen;

   public void TakeDamage(int damageAmount){
        
        health = health - damageAmount;
        SetHealth(health);
        if(health <=0){
            SetHealth(health);
            GameOver();
        }
    }

       public void GameOver(){
            Debug.Log("Game Over you LOST");
            GameOverScreen.Setup();
        }

        public void SetHealth(int health){
    
        slider.value = health;
    }
}
