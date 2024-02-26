using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random=UnityEngine.Random;
using TMPro;
using UnityEngine.UI;


public class B_AiMovement : MonoBehaviour
{
[Header("Player")]

    public static int Health = 2;

    public float moveCD = 4f;
    public bool movementOnGoing = true;
    public Vector3 movement;
    public Vector3 desiredPosition;
    public Vector3 smoothPosition;
    public float smoothSpeed;


[Header("Chess")]
public bool spawnavailable =false;

public float spawnCD = 4.0f;


    [SerializeField] private GameObject Pawn=null;
    public float pawnCastCD = 1.4f;
    [SerializeField] private GameObject BishopLeft=null;
    [SerializeField] private GameObject BishopRight=null;
    public float bishopCastCD = 2.0f;
    [SerializeField] private GameObject KnightLeft=null;
    [SerializeField] private GameObject KnightRight=null;
    public float knightCastCD = 1.8f;
    [SerializeField] private GameObject Rook=null;
    public float rookCastCD = 2.5f;

    [Header("Health")]
    [SerializeField] private Image hpBar;

    [SerializeField] private GameObject PlayerWinText;
    [SerializeField] private GameObject EndUI;





    // Start is called before the first frame update
    void Start()
    {
        desiredPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveCD-=Time.deltaTime;
        PlayerMove();
        CoolDown();
        if(moveCD>0&&transform.position.z%1==0)
        PlayerSpawn();

    }
    void FixedUpdate()
    {
      HealthCheck();  
    }
    private void HealthCheck(){
    if(Health<=0){
        Debug.Log("health0 - ai");
        Time.timeScale=0f;
        Health=2;
        EndUI.SetActive(true);
        PlayerWinText.SetActive(true);
    }
}

    private void PlayerMove(){
        
if(movementOnGoing && moveCD<=0){
    int check = Random.Range(0,2);
            if(check==0){
            movement = new Vector3(0,0,-2f);
        }else if(check==1){
            movement = new Vector3(0,0,2f);
        }
        movementOnGoing=false;
        desiredPosition = transform.position + movement;
        
        
        if(desiredPosition.z<0){
            desiredPosition.z=0;
        }if(desiredPosition.z>14){
            desiredPosition.z=14;
        }
        moveCD = 6f;
        }
        smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
         transform.position = smoothPosition;

        if(transform.position==desiredPosition){
        movement = new Vector3(0,0,0);
        if(transform.position.z%1==0){ }else{
            Vector3 adjust = new Vector3 (transform.position.x, 0,(float)Math.Round((double)transform.position.z));
            transform.position = adjust;
            
        movementOnGoing = true;
        
        }
        
        }
        
        
    }

    private void PlayerSpawn(){

        /*    if(Input.GetKeyDown(KeyCode.Q)){
                BishopSpawn();
            }
            
             if(Input.GetKeyDown(KeyCode.W)){
                KnightSpawn();

            }
             if(Input.GetKeyDown(KeyCode.E)){
                RookSpawn();
                
            }
             if(Input.GetKeyDown(KeyCode.Space)){
                PawnSpawn();
                
            }*/ 
            if(spawnCD>=0){
                spawnCD-= Time.deltaTime;
            }else if(spawnavailable){
            int check = Random.Range(0,4);
            switch(check){
                case 0:
                BishopSpawn();
                spawnCD=4.0f;
                break;
                case 1:
                KnightSpawn();
                spawnCD=4.0f;
                break;
                case 2:
                RookSpawn();
                spawnCD=4.0f;
                break;
                case 3:
                PawnSpawn();
                spawnCD=4.0f;
                break;
            }
            spawnavailable=false;
            }else{
                spawnavailable=true;
            
            }
            }


        


    void CoolDown(){
        //Bishop

        if(bishopCastCD>=0){
            bishopCastCD-=Time.deltaTime;
            
        }


        //Knight
        if(knightCastCD>=0){
            knightCastCD-=Time.deltaTime;
            
        }


        //Pawn
        if(pawnCastCD>=0){
            pawnCastCD-=Time.deltaTime;
           
        }

        


        //Rook

        if(rookCastCD>=0){
            rookCastCD-=Time.deltaTime;
            
        }
        


        
      
    }
    
public void BishopSpawn(){
    if(bishopCastCD<=0){
        int check = Random.Range(0,2);
                 
                if(check==0){
                    Vector3 spawnPosition = new Vector3(transform.position.x-2f,0,transform.position.z+2f);
                        if(spawnPosition.z>14){
                             spawnPosition = new Vector3(transform.position.x-2f,0,transform.position.z-2f);
                            Instantiate(BishopRight,spawnPosition,transform.rotation);
                        }else
                    Instantiate(BishopLeft,spawnPosition,transform.rotation);
                }
                else if(check==1){
                    Vector3 spawnPosition = new Vector3(transform.position.x-2f,0,transform.position.z-2f);
                    if(spawnPosition.z<0){
                             spawnPosition = new Vector3(transform.position.x-2f,0,transform.position.z+2f);
                            Instantiate(BishopLeft,spawnPosition,transform.rotation);
                        }else
                    Instantiate(BishopRight,spawnPosition,transform.rotation);
                }
               
    }
}

public void KnightSpawn(){
    if(knightCastCD<=0){
        int check = Random.Range(0,2);
                 
                if(check==0){
                    Vector3 spawnPosition = new Vector3(transform.position.x-4f,0,transform.position.z+2f);
                    if(spawnPosition.z>14){
                             spawnPosition = new Vector3(transform.position.x-2f,0,transform.position.z-2f);
                            Instantiate(KnightRight,spawnPosition,transform.rotation);
                        }else
                    Instantiate(KnightLeft,spawnPosition,transform.rotation);
                }
                else if(check==1){
                    Vector3 spawnPosition = new Vector3(transform.position.x-4f,0,transform.position.z-2f);
                    if(spawnPosition.z<0){
                             spawnPosition = new Vector3(transform.position.x-2f,0,transform.position.z+2f);
                            Instantiate(KnightLeft,spawnPosition,transform.rotation);
                        }else
                    Instantiate(KnightRight,spawnPosition,transform.rotation);
                }
                
                
}
}

public void RookSpawn(){
    if(rookCastCD<=0){
        Vector3 spawnPosition = new Vector3(transform.position.x-2f,0,transform.position.z);
                Instantiate(Rook,spawnPosition,transform.rotation);

                
    }
}

public void PawnSpawn(){
    if(pawnCastCD<=0){
        Vector3 spawnPosition = new Vector3(transform.position.x-2f,0,transform.position.z);
                Instantiate(Pawn,spawnPosition,transform.rotation);

               
    }
}

public void MoveLeft(){
    if(movementOnGoing){
        movement = new Vector3(0,0,2f);
        movementOnGoing=false;
        desiredPosition = transform.position + movement;
        
        
        if(desiredPosition.z<0){
            desiredPosition.z=0;
        }if(desiredPosition.z>14){
            desiredPosition.z=14;
        }
        
        }
        smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
         transform.position = smoothPosition;

        if(transform.position==desiredPosition){
        movement = new Vector3(0,0,0);
        
        movementOnGoing = true;
        }
    
    
}

public void MoveRight(){
    if(movementOnGoing){
        movement = new Vector3(0,0,-2f);
        movementOnGoing=false;
        desiredPosition = transform.position + movement;
        
        
        if(desiredPosition.z<0){
            desiredPosition.z=0;
        }if(desiredPosition.z>14){
            desiredPosition.z=14;
        }
        
        }
        smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
         transform.position = smoothPosition;

        if(transform.position==desiredPosition){
        movement = new Vector3(0,0,0);
        
        movementOnGoing = true;
        }

    
}

void OnTriggerEnter(Collider other)
{
    if(other.gameObject.tag=="white"){
            Debug.Log("AI hit ");
            Destroy(other.gameObject);
            LossHP(1);
        }
}

public void LossHP(int hp){
    Health-=hp;
    hpBar.fillAmount = (float)Health/2.0f;
}
public void AddHP(int HP){
    Health+=HP;
}
   

    
}
