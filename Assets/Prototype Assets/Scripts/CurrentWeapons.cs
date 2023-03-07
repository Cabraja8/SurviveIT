using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentWeapons : MonoBehaviour
{
   
    public Weapon MainGun;

    public Weapon SecondaryGun;

    public Weapon Melee;


   // dodat skriptu za dodavanje weapona u slotove, iz Weapon skripte treba maknut Change Weapon i napravit ga za ovu skriptu /

    private void Update() {

   if(Input.GetKeyDown(KeyCode.Alpha1)){
        FindObjectOfType<Player>().ChangeWeapon(MainGun);
    }
    if(Input.GetKeyDown(KeyCode.Alpha2)){
        FindObjectOfType<Player>().ChangeWeapon(SecondaryGun);
    }
     if(Input.GetKeyDown(KeyCode.Alpha3)){
        FindObjectOfType<Player>().ChangeWeapon(Melee);
    }
    }
    }

    


