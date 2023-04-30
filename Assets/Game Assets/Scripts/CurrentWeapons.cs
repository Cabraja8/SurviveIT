 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrentWeapons : MonoBehaviour
{
   

    public string pickup;
   
   public KeyCode[] switchKeys = { KeyCode.Alpha1, KeyCode.Alpha2 , KeyCode.Alpha3 };
    public GameObject[] weaponsSlots;

    public Image[] weaponimgIndex;
    public Image[] CurrentWeaponImg;
    public Sprite[] ImageOfWeapons;
    public TMP_Text[] AmmoTypeShow;

    public GameObject[] Weapons;
    public int currentWeaponIndex = 1;




    public void UpdateDisplay(int Ammo){
          for (int i = 0; i < AmmoTypeShow.Length; i++)
        {   
            if(i==2){
                DisableWepDisplay();
            }else{

            if (i == currentWeaponIndex)
            {   
                 if(weaponimgIndex[i] != null){
                AmmoTypeShow[i].text=Ammo.ToString();
                 }
            }
          
            }
        }
    }

    private void Start()
    {       
        
        
        for (int i = 2; i < weaponsSlots.Length; i++)
        {    if(weaponsSlots[i] != null){
            weaponsSlots[i].SetActive(false);
        }
        }
        SetCurrentIndex(1);
        SetCurrentText(1);
      
    }
    

     private void Update()
    {
        
        for (int i = 0; i < switchKeys.Length; i++)
        {   
            if(weaponsSlots[i] != null){
            if (Input.GetKeyDown(switchKeys[i]))
            {
                currentWeaponIndex = i;
                SetCurrentWeapon(currentWeaponIndex);
                SetCurrentIndex(currentWeaponIndex);
            }
        }
        }

        if(  FindObjectOfType<MeleeWeapon>()){

        
           DisableWepDisplay();
        }
        else{
            SetCurrentText(currentWeaponIndex);
            SetCurrentIndex(currentWeaponIndex);
        }
        
    }

    public void SetCurrentIndex(int weaponIndex){
          for (int i = 0; i < weaponimgIndex.Length; i++)
        {
            if (i == weaponIndex)
            {   
                 if(weaponimgIndex[i] != null){
                weaponimgIndex[i].enabled=true;
                 }
            }
            else
            {   
                 if(weaponimgIndex[i] != null){
                weaponimgIndex[i].enabled=false;
                 }
            }
        }

    }

    public void SetCurrentText(int weaponIndex){
           for (int i = 0; i < AmmoTypeShow.Length; i++)
        {
            if (i == weaponIndex)
            {   
                 if(AmmoTypeShow[i] != null){
                AmmoTypeShow[i].enabled=true;
                 }
            }
            else
            {   
                 if(AmmoTypeShow[i] != null){
                AmmoTypeShow[i].enabled=false;
                 }
            }
        }
    }

    public void DisableWepDisplay(){
              for (int i = 0; i < AmmoTypeShow.Length; i++)
        {
           
                 if(AmmoTypeShow[i] != null){
                AmmoTypeShow[i].enabled=false;
                 
            }
        }
    }

    public void SetCurrentWeapon(int weaponIndex)
    {
        
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
                CurrentWeaponImg[0].sprite = ImageOfWeapons[1];
                
                weaponsSlots[0] = null;
                currentWeaponIndex = 0;
            }
            SetCurrentIndex(0);
            CurrentWeaponImg[0].sprite = ImageOfWeapons[1];
            currentWeaponIndex = 0;
            weaponsSlots[0] = null;
            weaponsSlots[0] =weapon;
            weaponsSlots[0].SetActive(true);
           
            weaponIndex = i;
            weaponsSlots[0] = Weapons[1];
            
            SetCurrentWeapon(0);
            
            
             }
         else if(pickup=="glock-18"){
            if(currentWeaponIndex==1){
                weaponsSlots[1].SetActive(false);
                CurrentWeaponImg[1].sprite = ImageOfWeapons[0];
                weaponsSlots[1] = null;
                currentWeaponIndex = 1;
                SetCurrentIndex(1);
            }
            SetCurrentIndex(1);
            CurrentWeaponImg[1].sprite = ImageOfWeapons[0];
            currentWeaponIndex=1;
            weaponsSlots[1] = null;
            weaponsSlots[1] =weapon;
            weaponsSlots[1].SetActive(true);
            weaponIndex = i;
             weaponsSlots[1] = Weapons[0];
            SetCurrentWeapon(1);
            
             }
             else if(pickup=="m14"){
                 if(currentWeaponIndex==0){
                weaponsSlots[0].SetActive(false);
                CurrentWeaponImg[0].sprite = ImageOfWeapons[3];
                weaponsSlots[0] = null;
                currentWeaponIndex = 0;
                SetCurrentIndex(0);
            }
            SetCurrentIndex(0);
            CurrentWeaponImg[0].sprite = ImageOfWeapons[3];
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
                CurrentWeaponImg[0].sprite = ImageOfWeapons[4];
                weaponsSlots[0] = null;
                currentWeaponIndex = 0;
                SetCurrentIndex(0);
            }
            SetCurrentIndex(0);
            CurrentWeaponImg[0].sprite = ImageOfWeapons[4];
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
                CurrentWeaponImg[0].sprite = ImageOfWeapons[5];
                weaponsSlots[0] = null;
                currentWeaponIndex = 0;
                SetCurrentIndex(0);
            }
            SetCurrentIndex(0);
            CurrentWeaponImg[0].sprite = ImageOfWeapons[5];
            currentWeaponIndex = 0;
            weaponsSlots[0] = null;
            weaponsSlots[0] =weapon;
            weaponsSlots[0].SetActive(true);
            weaponIndex = i;
            weaponsSlots[0] = Weapons[5];
            SetCurrentWeapon(0);
        }

         
        else if(pickup=="colt_m1911"){
                 if(currentWeaponIndex==1){
                weaponsSlots[1].SetActive(false);
                CurrentWeaponImg[1].sprite = ImageOfWeapons[2];
                weaponsSlots[1] = null;
                currentWeaponIndex = 1;
                SetCurrentIndex(1);
            }
           SetCurrentIndex(1);
           CurrentWeaponImg[1].sprite = ImageOfWeapons[2];
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
                CurrentWeaponImg[2].sprite = ImageOfWeapons[6];
                SetCurrentIndex(2);
                weaponsSlots[2] = null;
                currentWeaponIndex = 2;
            }
           SetCurrentIndex(2);
            CurrentWeaponImg[2].sprite = ImageOfWeapons[6];
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
                CurrentWeaponImg[2].sprite = ImageOfWeapons[7];
                SetCurrentIndex(2);
                weaponsSlots[2] = null;
                currentWeaponIndex = 2;
            }
           SetCurrentIndex(2);
            currentWeaponIndex=2;
            CurrentWeaponImg[2].sprite = ImageOfWeapons[7];
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