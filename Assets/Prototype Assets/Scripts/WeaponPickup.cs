using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponPickup : MonoBehaviour
{
    public TMP_Text EquipSign;
    public TMP_Text AlreadyEquiped;

    

    public GameObject WeaponToEquip;
    float distance = Mathf.Infinity;
    float distanceToPlayer = 3f;
    [SerializeField] Transform player;
    public bool isEquiped=false;
    public bool inRange=false;

    public GameObject[] currentweapons;

   

    
    private void Start() {
        player = FindObjectOfType<Player>().transform;
        currentweapons = FindObjectOfType<CurrentWeapons>().weaponsSlots;
        EquipSign.enabled =false;
        AlreadyEquiped.enabled=false;

         
        
    }

    private void Update() {
        distance = Vector2.Distance(player.position,transform.position);
        if (distance  <= distanceToPlayer ){
            inRange=true;
            if(Input.GetKeyDown(KeyCode.T)){
            for(int i=0;i<currentweapons.Length;i++){
             if(currentweapons[i] != null ){
                if(currentweapons[i].name == WeaponToEquip.name){
                    AlreadyEquiped.enabled=true;
                    isEquiped=true;
                    Debug.Log("You already equiped that weapon"); // funkcija koja samo prikazuje da ima equipano 
                     
                     
                 Invoke("UnEquiped",2.0f); 
                 }
             }
                }
                 if(!isEquiped){
                 FindObjectOfType<Player>().PickupItem();
                 FindObjectOfType<CurrentWeapons>().pickup=WeaponToEquip.name;
                 FindObjectOfType<CurrentWeapons>().ChangeWeapon(WeaponToEquip);
                 Destroy(gameObject);
                 }
                }
            }
        }
        public void UnEquiped(){
             isEquiped = false;
             AlreadyEquiped.enabled=false;
           
             
        }
    }
    

