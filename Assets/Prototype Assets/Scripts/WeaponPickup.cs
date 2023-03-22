using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{

    public GameObject WeaponToEquip;
    float distance = Mathf.Infinity;
    float distanceToPlayer = 3f;
    [SerializeField] Transform player;
    public bool isEquiped=false;

    public GameObject[] currentweapons;

   

    
    private void Start() {
        player = FindObjectOfType<Player>().transform;
        currentweapons = FindObjectOfType<CurrentWeapons>().weaponsSlots;
        
    }

    private void Update() {
        distance = Vector2.Distance(player.position,transform.position);

        if (distance  <= distanceToPlayer ){
            if(Input.GetKeyDown(KeyCode.T)){
            for(int i=0;i<currentweapons.Length;i++){
             if(currentweapons[i] != null ){
                if(currentweapons[i].name == WeaponToEquip.name){
                    isEquiped=true;
                    Debug.Log(currentweapons[i].name + " name 1");
                    Debug.Log("You already equiped that weapon"); // funkcija koja samo prikazuje da ima equipano 
                 Invoke("UnEquiped",2.0f);
                }else{
                 if(!isEquiped){
                 FindObjectOfType<Player>().PickupItem();
                 FindObjectOfType<CurrentWeapons>().pickup=WeaponToEquip.name;
                 FindObjectOfType<CurrentWeapons>().ChangeWeapon(WeaponToEquip);
                 Destroy(gameObject);
                    break;
                 }
                }

             }

                }
                   
            }

           
          
            
            
            }
        }

        public void UnEquiped(){
             isEquiped = false;
        }
    }
    

