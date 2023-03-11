using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{

    public Weapon WeaponToEquip;
    float distance = Mathf.Infinity;
    float distanceToPlayer = 3f;
    [SerializeField] Transform player;

    
    private void Start() {
        player = FindObjectOfType<Player>().transform;
        
    }

    private void Update() {
        distance = Vector2.Distance(player.position,transform.position);

        if (distance  <= distanceToPlayer ){
            if(Input.GetKeyDown(KeyCode.T)){
                 Debug.Log("weapon picked up");
            FindObjectOfType<Player>().ChangeWeapon(WeaponToEquip);
            Destroy(gameObject);
            }
        }
    }
    
}
