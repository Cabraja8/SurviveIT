using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponPickup : MonoBehaviour
{
    
    public TMP_Text AlreadyEquiped;
    public GameObject WeaponToEquip;
    float distance = Mathf.Infinity;
    float distanceToPlayer = 3f;
    [SerializeField] Transform player;
    public bool isEquiped=false;
    public bool inRange=false;
    public GameObject[] currentweapons;

    public int DestoryDelay=10;

   

    
    private void Start() {
        player = FindObjectOfType<Player>().transform;
        AlreadyEquiped = FindObjectOfType<DisableText>().AlreadyEquiped;
        AlreadyEquiped.enabled=false;
        currentweapons = FindObjectOfType<CurrentWeapons>().weaponsSlots;

        StartCoroutine(DestoryWeapon());
    }

    IEnumerator DestoryWeapon(){
        yield return new WaitForSeconds(DestoryDelay);
        GameObject ObjToRemove=gameObject;

        Destroy(ObjToRemove);
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
                    Debug.Log("You already equiped that weapon"); 
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
    

