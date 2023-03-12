using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectile;

    public Weapon weapon;

    public Transform shotPoint;
    public Transform shotPoint2;
    public Transform shotPointHelper;

    public SpriteRenderer rend;

    public SpriteRenderer Fire1;
    public SpriteRenderer Fire2;

    public int Ammo;

    public int bullets;

    public int shells;

    public int HandgunBullets;

    public float timeBetweenShots;

    private float shotTime;

    

    public int GetCurrentAmmo(){
        return Ammo;
    }





    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        Fire1.enabled = false;
        Fire2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetAmmo();
        GetCurrentWeapon();
        WeaponControl();

       
    
    if(Ammo >0){
        if(Input.GetMouseButton(0)){
            if(Time.time >= shotTime){
                Shoot();
            }
        }
        else{
            Fire1.enabled = false;
            Fire2.enabled = false;
        }
    }
    if(Ammo == 0){
        
        Fire1.enabled = false;
        Fire2.enabled = false;
    }

    if(Input.GetKeyDown(KeyCode.R)){

        Debug.Log(gameObject.tag);
        if(gameObject.tag == "Assault Rifle"){
        ReloadGun();
        }
        else if(gameObject.tag == "Shotgun") {
        ReloadShotgun();
        }else if(gameObject.tag =="HandGun"){
         ReloadHandgun();
        }
       
    }
    }

    void WeaponControl(){
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float angle= Mathf.Atan2(direction.y,direction.x)* Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle -90f, Vector3.forward);

        transform.rotation = rotation;

        if(angle >=90 || angle<= -90){
            rend.flipX = true;
            shotPoint = shotPoint2;
        }
        else{
            rend.flipX = false;
            shotPoint=shotPointHelper;

        }
    }
    

    
    public Weapon GetCurrentWeapon(){
       return FindObjectOfType<Weapon>();
    }
    void GetAmmo(){
        bullets = FindObjectOfType<WeaponAmmoDisplay>().GetCurrentBullets();
        shells = FindObjectOfType<WeaponAmmoDisplay>().GetCurrentShells();
        HandgunBullets = FindObjectOfType<WeaponAmmoDisplay>().GetCurrentHandgunBullets();
    }


    void ReloadShotgun(){
      
        if(shells >9 ){
        int s;
        int max=10;
        s= max-Ammo;
        Ammo = 10;
        shells = shells-s;
        FindObjectOfType<WeaponAmmoDisplay>().DecreaseShells(shells);
        }
        else if (shells <10){
            if(shells + Ammo == 10){
                Ammo = 10;
                shells = 0;
                FindObjectOfType<WeaponAmmoDisplay>().DecreaseShells(shells);
            }
            else{
                Ammo = shells + Ammo;
                shells = 0;
                FindObjectOfType<WeaponAmmoDisplay>().DecreaseShells(shells);
            }
        }
        else if(shells == 10  ){
            Ammo =10;
            shells = 0;
            FindObjectOfType<WeaponAmmoDisplay>().DecreaseShells(shells);
            }else{
            Debug.Log("No Ammo Left");
        }
    }
    void ReloadGun(){
        if(bullets >9 ){
        int s;
        int max=10;
        s= max-Ammo;
        Ammo = 10;
        bullets = bullets-s;
        FindObjectOfType<WeaponAmmoDisplay>().DecreaseBullets(bullets);
        }
        else if (bullets <10){
            if(bullets + Ammo == 10){
                Ammo = 10;
                bullets = 0;
                FindObjectOfType<WeaponAmmoDisplay>().DecreaseBullets(bullets);
            }
            else{
                Ammo = bullets + Ammo;
                bullets = 0;
                FindObjectOfType<WeaponAmmoDisplay>().DecreaseBullets(bullets);
            }
        }
        else if(bullets == 10  ){
            Ammo =10;
            bullets = 0;
            FindObjectOfType<WeaponAmmoDisplay>().DecreaseBullets(bullets);
            }else{
            Debug.Log("No Ammo Left");
        }

    }

    void ReloadHandgun(){
         if(HandgunBullets >9 ){
        int s;
        int max=10;
        s= max-Ammo;
        Ammo = 10;
        HandgunBullets = HandgunBullets-s;
        FindObjectOfType<WeaponAmmoDisplay>().DecreaseHandgunBullets(HandgunBullets);
        }
        else if (HandgunBullets <10){
            if(HandgunBullets + Ammo == 10){
                Ammo = 10;
                HandgunBullets = 0;
                FindObjectOfType<WeaponAmmoDisplay>().DecreaseHandgunBullets(HandgunBullets);
            }
            else{
                Ammo = HandgunBullets + Ammo;
                HandgunBullets = 0;
                FindObjectOfType<WeaponAmmoDisplay>().DecreaseHandgunBullets(HandgunBullets);
            }
        }
        else if(HandgunBullets == 10  ){
            Ammo =10;
            HandgunBullets = 0;
            FindObjectOfType<WeaponAmmoDisplay>().DecreaseHandgunBullets(HandgunBullets);
            }else{
            Debug.Log("No Ammo Left");
        }


    }

    void Shoot(){
        Ammo--;
        Instantiate(projectile ,shotPoint.position, transform.rotation );
        if(!rend.flipX){
        Fire1.enabled = true;
        }else if(rend.flipX){
        Fire2.enabled = true;
        }
        shotTime = Time.time + timeBetweenShots;
    }

  
}
