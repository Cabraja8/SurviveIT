using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentWeapons : MonoBehaviour
{
   

    public string pickup;
   
   public KeyCode[] switchKeys = { KeyCode.Alpha1, KeyCode.Alpha2 , KeyCode.Alpha3 };
    public GameObject[] weaponsSlots;

    public GameObject[] Weapons;
    public int currentWeaponIndex = 1;

    private void Start()
    {       
        
        // Deactivate all weapons except the first one
        for (int i = 2; i < weaponsSlots.Length; i++)
        {    if(weaponsSlots[i] != null){
            weaponsSlots[i].SetActive(false);
        }
        }
    }

     private void Update()
    {
        // Switch to the next weapon if the corresponding key is pressed
        for (int i = 0; i < switchKeys.Length; i++)
        {   
            if(weaponsSlots[i] != null){
            if (Input.GetKeyDown(switchKeys[i]))
            {
                currentWeaponIndex = i;
                SetCurrentWeapon(currentWeaponIndex);
            }
        }
        }
    }

    public void SetCurrentWeapon(int weaponIndex)
    {
        // Deactivate all weapons except for the selected one
        for (int i = 0; i < weaponsSlots.Length; i++)
        {
            if (i == weaponIndex)
            {   
                 if(weaponsSlots[i] != null){
                weaponsSlots[i].SetActive(true);
                 }
            }
            else
            {   
                 if(weaponsSlots[i] != null){
                weaponsSlots[i].SetActive(false);
                 }
            }
        }
    }

   

   

    public void ChangeWeapon(GameObject weapon){

      
       
        int weaponIndex = -1;
        for (int i = 0; i < weaponsSlots.Length; i++)
        {   
            if(weaponsSlots[i] != null){

                weaponsSlots[i].SetActive(false);

         if(pickup=="ak47"){
            if(currentWeaponIndex==0){
                weaponsSlots[0].SetActive(false);
                
                weaponsSlots[0] = null;
                currentWeaponIndex = 0;
            }
            currentWeaponIndex = 0;
            weaponsSlots[0] = null;
            weaponsSlots[0] =weapon;
            weaponsSlots[0].SetActive(true);
           
            weaponIndex = i;
            weaponsSlots[0] = Weapons[1];
            
            SetCurrentWeapon(0);
            
            
             }
             else if(pickup=="m14"){
                 if(currentWeaponIndex==0){
                weaponsSlots[0].SetActive(false);
                
                weaponsSlots[0] = null;
                currentWeaponIndex = 0;
            }
            
            currentWeaponIndex = 0;
            weaponsSlots[0] = null;
            weaponsSlots[0] =weapon;
            weaponsSlots[0].SetActive(true);
            weaponIndex = i;
            weaponsSlots[0] = Weapons[3];
          
            SetCurrentWeapon(0);
            
            
             }
        else if(pickup=="m16"){
            if(currentWeaponIndex==0){
                weaponsSlots[0].SetActive(false);
                
                weaponsSlots[0] = null;
                currentWeaponIndex = 0;
            }
            
            currentWeaponIndex = 0;
            weaponsSlots[0] = null;
            weaponsSlots[0] =weapon;
            weaponsSlots[0].SetActive(true);
            weaponIndex = i;
            weaponsSlots[0] = Weapons[4];
            SetCurrentWeapon(0);
            
            
             }
        else if(pickup=="remington"){
            if(currentWeaponIndex==0){
                weaponsSlots[0].SetActive(false);
                
                weaponsSlots[0] = null;
                currentWeaponIndex = 0;
            }
            
            currentWeaponIndex = 0;
            weaponsSlots[0] = null;
            weaponsSlots[0] =weapon;
            weaponsSlots[0].SetActive(true);
            weaponIndex = i;
            weaponsSlots[0] = Weapons[5];
           
            SetCurrentWeapon(0);
            
            
        }

         
         else if(pickup=="glock-18"){
            if(currentWeaponIndex==1){
                weaponsSlots[1].SetActive(false);
                
                weaponsSlots[1] = null;
                currentWeaponIndex = 1;
            }
            
            currentWeaponIndex=1;
            weaponsSlots[1] = null;
            weaponsSlots[1] =weapon;
            weaponsSlots[1].SetActive(true);
            weaponIndex = i;
             weaponsSlots[1] = Weapons[0];
            SetCurrentWeapon(1);
            
             }
              else if(pickup=="colt_m1911"){
                 if(currentWeaponIndex==1){
                weaponsSlots[1].SetActive(false);
                
                weaponsSlots[1] = null;
                currentWeaponIndex = 1;
            }
           
            currentWeaponIndex=1;
                weaponsSlots[1] = null;
            weaponsSlots[1] =weapon;
            weaponsSlots[1].SetActive(true);
            weaponIndex = i;
             weaponsSlots[1] = Weapons[2];
            SetCurrentWeapon(1);
            
             }
             else if(pickup=="crowbar"){
                 if(currentWeaponIndex==2){
                weaponsSlots[2].SetActive(false);
                
                weaponsSlots[2] = null;
                currentWeaponIndex = 2;
            }
           
            currentWeaponIndex=2;
                weaponsSlots[2] = null;
            weaponsSlots[2] =weapon;
            weaponsSlots[2].SetActive(true);
            weaponIndex = i;
             weaponsSlots[2] = Weapons[6];
            SetCurrentWeapon(2);
            
             }
              else if(pickup=="Knife"){
                 if(currentWeaponIndex==2){
                weaponsSlots[2].SetActive(false);
                
                weaponsSlots[2] = null;
                currentWeaponIndex = 2;
            }
           
            currentWeaponIndex=2;
                weaponsSlots[2] = null;
            weaponsSlots[2] =weapon;
            weaponsSlots[2].SetActive(true);
            weaponIndex = i;
             weaponsSlots[2] = Weapons[7];
            SetCurrentWeapon(2);
            
             }
            }
        }
  

    }
    
    
}


    

    


