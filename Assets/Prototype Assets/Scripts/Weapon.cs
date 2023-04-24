using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public int MaxAmmo;

    public float timeBetweenShots;

    private float shotTime;


    public AudioSource audiosource;

    public AudioClip ReloadSound;

    public AudioClip ShotSound;

    public TMP_Text reloadSign;

    public bool Reloading= false;

  


    // Start is called before the first frame update
    void Start()
    {   
        reloadSign.enabled=false;
        rend = GetComponent<SpriteRenderer>();
        Fire1.enabled = false;
        Fire2.enabled = false;
    }

    public void UpdateAmmo(){

    FindObjectOfType<CurrentWeapons>().UpdateDisplay(Ammo);
    }

    // Update is called once per frame
    void Update()
    {
        GetAmmo();
        GetCurrentWeapon();
        if(!PauseMenu.GameIsPaused){

        WeaponControl();
        }
        UpdateAmmo();
    
    if(Ammo >0){
        if (Input.GetMouseButtonDown(0) && !PauseMenu.GameIsPaused){
            Fire1.enabled = false;
            Fire2.enabled = false;
        }

        if(Input.GetMouseButton(0) && !PauseMenu.GameIsPaused){
            if(Time.time >= shotTime){
                if(!Reloading){
                Shoot();
                }
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
        reloadSign.enabled=true;
    }
    if(Reloading){
        reloadSign.enabled=false;
    }

    if(Input.GetKeyDown(KeyCode.R) && !PauseMenu.GameIsPaused){

        
        if(Ammo == MaxAmmo){
            Debug.Log("ammo full");
        }
        if(gameObject.tag == "Assault Rifle"){
        if(Ammo != MaxAmmo && bullets !=0){
        Reloading = true;
        audiosource.PlayOneShot(ReloadSound);
        Invoke("ReloadGun",1.5f);
        }
        }
        else if(gameObject.tag == "Shotgun") {
        if(Ammo != MaxAmmo && shells !=0){
        Reloading = true;
        audiosource.PlayOneShot(ReloadSound);
        
        Invoke("ReloadShotgun",2.0f);
            }
        }else if(gameObject.tag =="HandGun"){
        if(Ammo != MaxAmmo && HandgunBullets !=0){
        Reloading = true;
        audiosource.PlayOneShot(ReloadSound);
        
        Invoke("ReloadHandgun",1.0f);
            }
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

        Reloading = false;
      
       int reloadAmount=MaxAmmo - Ammo;
        reloadAmount = (shells - reloadAmount)>= 0 ? reloadAmount : shells;
        Ammo += reloadAmount;
        shells -=reloadAmount;
         FindObjectOfType<WeaponAmmoDisplay>().DecreaseShells(shells);
         FindObjectOfType<WeaponAmmoDisplay>().UpdateDisplay();
    }
    void ReloadGun(){
        Reloading = false;
        int reloadAmount=MaxAmmo - Ammo;
        reloadAmount = (bullets - reloadAmount)>= 0 ? reloadAmount : bullets;
        Ammo += reloadAmount;
        bullets -=reloadAmount;
         FindObjectOfType<WeaponAmmoDisplay>().DecreaseBullets(bullets);
         FindObjectOfType<WeaponAmmoDisplay>().UpdateDisplay();
    }

    void ReloadHandgun(){


        Reloading = false;
      
        int reloadAmount=MaxAmmo - Ammo;
        reloadAmount = (HandgunBullets - reloadAmount)>= 0 ? reloadAmount : HandgunBullets;
        Ammo += reloadAmount;
        HandgunBullets -=reloadAmount;
         FindObjectOfType<WeaponAmmoDisplay>().DecreaseHandgunBullets(HandgunBullets);
         FindObjectOfType<WeaponAmmoDisplay>().UpdateDisplay();

    }

    void Shoot(){
        Ammo--;
        audiosource.PlayOneShot(ShotSound);
        Instantiate(projectile ,shotPoint.position, transform.rotation );
        if(!rend.flipX){
        Fire1.enabled = true;
        }else if(rend.flipX){
        Fire2.enabled = true;
        }
        shotTime = Time.time + timeBetweenShots;
    }

  
}
