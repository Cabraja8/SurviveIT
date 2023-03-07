using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBarricade : MonoBehaviour
{   
    float distance = Mathf.Infinity;
    float distanceToPlayer = 4f;
    [SerializeField] Transform player;
    public Collider2D barricade;
    public Renderer barricadeSprite;

    public int planks;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        barricade = GetComponent<BoxCollider2D>();
        barricadeSprite = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }

    void CheckDistance(){
         distance = Vector2.Distance(player.position,transform.position);

        if (distance  <= distanceToPlayer ){
            if(Input.GetKeyDown(KeyCode.F)){
                if(planks>=1){
                    planks--;
                    barricade.enabled = true;
                    barricadeSprite.enabled = true;
                }
                else{
                    Debug.Log("there's no more planks");
                }
            }
        }
        if(distance  >= distanceToPlayer ){
             Debug.Log("Player is not close");
        }


    }

    public void IncreasePlanks(int plankAmount){
        planks = planks + plankAmount;
    }
}
