using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAmmoDisplay : MonoBehaviour
{   
    public int bullets;

    public int shells;

    public int HandgunBullets;

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
    }
    public void DecreaseShells(int shellAmount){
        shells= shellAmount;
    }
    public void IncreaseHandgunBullets(int BulletAmount){
        HandgunBullets = HandgunBullets + BulletAmount;
     }

     public void DecreaseHandgunBullets(int BulletAmount){
         HandgunBullets = BulletAmount;
     }


     public void IncreaseBullets(int BulletAmount){
        bullets=bullets + BulletAmount;
    }
    public void DecreaseBullets(int BulletAmount){
        bullets= BulletAmount;
    }

}
