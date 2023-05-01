using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarricadeSpot : MonoBehaviour
{
   
       public AudioClip BreakSound;
    public AudioClip BuildSound;
    public AudioSource audisource;
    public GameObject eastSign;
    public GameObject westSign;
    public GameObject[] barricades; 
    public int maxHealth = 100; 
    public int currentHealth; 
    public bool isOccupied; 
    public float plankCost = 1f; 
    
    public float rebuildCooldown = 2f; 
    private float nextRebuildTime = 0f; 

    private Renderer renderer; 
    private Color defaultColor; 

    private void Start()
    {
        renderer = GetComponentInChildren<Renderer>();
        defaultColor = renderer.material.color;
        currentHealth = maxHealth;
    }

    public void NotOcupied(){
        this.isOccupied=false;
    }

    private void Update()
    {
      
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
           
            if (isOccupied || Time.time < nextRebuildTime || FindObjectOfType<Player>().planks < plankCost)
            {
                renderer.material.color = Color.red;
            }
            else
            {
                renderer.material.color = Color.green;
            }

          
            if (Input.GetKeyDown(KeyCode.F) && !isOccupied && Time.time >= nextRebuildTime && FindObjectOfType<Player>().planks >= plankCost)
            {
                audisource.PlayOneShot(BuildSound);
            
                foreach (GameObject barricade in barricades)
                {
                    if (!barricade.activeSelf)
                    {
                        barricade.SetActive(true);
                        barricade.transform.position = transform.position;
                        barricade.transform.rotation = transform.rotation;
                        break;
                    }
                }

                
                isOccupied = true;
                FindObjectOfType<Player>().planks -= plankCost;

                FindObjectOfType<BuildBarricade>().UpdateDisplay();
            }
        }
        else
        {
          
            renderer.material.color = defaultColor;
        }
    }

    public void TakeDamage(BarricadeSpot barricadeSpot)
    {
          
            barricadeSpot.isOccupied = false;
            
            barricadeSpot.nextRebuildTime = Time.time + rebuildCooldown;
            
            foreach (Transform child in transform)
            {
                if (child.CompareTag("Barricade"))
                {
                    child.gameObject.SetActive(false);
                }
            }
        
    }

}
