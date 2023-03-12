using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentWeapons : MonoBehaviour
{
   
   public Weapon weapon;

    public Weapon MainGun;

    public Weapon SecondaryGun;

    public Weapon Melee;


    public void MainGunChange(Weapon Equip){
        MainGun = Equip;
    }
    
     public void HandGunChange(Weapon Equip){
        SecondaryGun = Equip;
    }
  

    private void Update() {
    if(MainGun !=null){
   if(Input.GetKeyDown(KeyCode.Alpha1)){
        
        FindObjectOfType<Player>().ChangeWeapon(MainGun);
        weapon = MainGun;
    }
    }
    if(SecondaryGun !=null){
    if(Input.GetKeyDown(KeyCode.Alpha2)){
     
        FindObjectOfType<Player>().ChangeWeapon(SecondaryGun);
        weapon = SecondaryGun;
    }
    }
    if(Melee !=null){
     if(Input.GetKeyDown(KeyCode.Alpha3)){
      
        FindObjectOfType<Player>().ChangeWeapon(Melee);
        weapon = Melee;
    }
    }
    }
    }

    


