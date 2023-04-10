using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class WeaponAmmoDisplay : MonoBehaviour
{   
    public int bullets;

    public int shells;

    public int HandgunBullets;

    [SerializeField] TextMeshProUGUI displayBullets;
    [SerializeField] TextMeshProUGUI displayShotgunShells;
    [SerializeField] TextMeshProUGUI displayHandGunBullets;



   
     public void UpdateDisplay(){
        displayBullets.text = bullets.ToString();
        displayShotgunShells.text = shells.ToString();
        displayHandGunBullets.text = HandgunBullets.ToString();
    }
    

    public int GetCurrentBullets(){
        return bullets;
    }
    public int GetCurrentShells(){
        return shells;
    }
    public int GetCurrentHandgunBullets(){
        return HandgunBullets;
    }
    


    public void IncreaseShells(int shellAmount){
        shells=shells + shellAmount;
        UpdateDisplay();
    }
    public void DecreaseShells(int shellAmount){
        
        shells= shellAmount;
        if(shells<1){
            shells=0;
        }
        UpdateDisplay();

        
    }
    public void IncreaseHandgunBullets(int BulletAmount){
        HandgunBullets = HandgunBullets + BulletAmount;
        UpdateDisplay();
     }

     public void DecreaseHandgunBullets(int BulletAmount){
         HandgunBullets = BulletAmount;
         if(BulletAmount<1){
            BulletAmount=0;
        }
        UpdateDisplay();
     }


     public void IncreaseBullets(int BulletAmount){
        bullets=bullets + BulletAmount;
        UpdateDisplay();
    }
    public void DecreaseBullets(int BulletAmount){
        bullets= BulletAmount;
         if(bullets<1){
            bullets=0;
        }
    UpdateDisplay();
    }
}
