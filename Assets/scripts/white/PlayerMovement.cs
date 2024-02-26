using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Random=UnityEngine.Random;

public class PlayerMovement : MonoBehaviour
{
[Header("Player")]

    public static int Health = 2;
    public bool movementOnGoing = true;
    public Vector3 movement;
    public Vector3 desiredPosition;
    public Vector3 smoothPosition;
    public float smoothSpeed;


[Header("Chess")]
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



[Header("UI items for Spell Cooldown")]
    
    [SerializeField] private Image pawnImageCD;
    [SerializeField] private TMP_Text pawntxtCD; 
    

    [SerializeField] private Image bishopImageCD;
    [SerializeField] private TMP_Text bishoptxtCD;


    [SerializeField] private Image knightImageCD;
    [SerializeField] private TMP_Text knighttxtCD;

    [SerializeField] private Image rookImageCD;
    [SerializeField] private TMP_Text rooktxtCD;

    [Header("Health")]
    [SerializeField] private Image hpBar;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        CoolDown();
        PlayerSpawn();

    }
    void FixedUpdate()
    {
      HealthCheck();  
    }

private void HealthCheck(){
    if(Health<0){
        Debug.Log("health0 - player");
    }
}
    private void PlayerMove(){
if(movementOnGoing){
            if(Input.GetKeyDown(KeyCode.RightArrow)){
            movement = new Vector3(0,0,-2f);
        }if(Input.GetKeyDown(KeyCode.LeftArrow)){
            movement = new Vector3(0,0,2f);
        }
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
        if(transform.position.z%1==0){ }else{
            Vector3 adjust = new Vector3 (transform.position.x, transform.position.y,(float)Math.Round((double)transform.position.z));
            transform.position = adjust;
            
        }
        
        movementOnGoing = true;
        }
    }

    private void PlayerSpawn(){

            if(Input.GetKeyDown(KeyCode.Q)){
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
                
            }
        }


    void CoolDown(){
        //Bishop

        if(bishopCastCD>=0){
            bishopCastCD-=Time.deltaTime;
            bishoptxtCD.text = Mathf.RoundToInt(bishopCastCD).ToString();
            bishopImageCD.fillAmount = bishopCastCD / 2.0f;
        } else{
            bishoptxtCD.gameObject.SetActive(false);
            bishopImageCD.fillAmount = 0.0f;
        }


        //Knight
        if(knightCastCD>=0){
            knightCastCD-=Time.deltaTime;
            knighttxtCD.text = Mathf.RoundToInt(knightCastCD).ToString();
            knightImageCD.fillAmount = knightCastCD / 1.8f;
        } else{
            knighttxtCD.gameObject.SetActive(false);
            knightImageCD.fillAmount = 0.0f;
        }


        //Pawn
        if(pawnCastCD>=0){
            pawnCastCD-=Time.deltaTime;
            pawntxtCD.text = Mathf.RoundToInt(pawnCastCD).ToString();
            pawnImageCD.fillAmount = pawnCastCD / 1.4f;
        } else{
            pawntxtCD.gameObject.SetActive(false);
            pawnImageCD.fillAmount = 0.0f;
        }

        


        //Rook

        if(rookCastCD>=0){
            rookCastCD-=Time.deltaTime;
            rooktxtCD.text = Mathf.RoundToInt(rookCastCD).ToString();
            rookImageCD.fillAmount = rookCastCD / 2.5f;
        } else{
            rooktxtCD.gameObject.SetActive(false);
            rookImageCD.fillAmount = 0.0f;
        }
        


        
      
    }
    
public void BishopSpawn(){
    if(bishopCastCD<=0){
        int check = Random.Range(0,2);
                 
                if(check==0){
                    Vector3 spawnPosition = new Vector3(transform.position.x+2f,transform.position.y,transform.position.z+2f);
                        if(spawnPosition.z>14){
                             spawnPosition = new Vector3(transform.position.x+2f,transform.position.y,transform.position.z-2f);
                            Instantiate(BishopRight,spawnPosition,transform.rotation);
                        }else
                    Instantiate(BishopLeft,spawnPosition,transform.rotation);
                }
                else if(check==1){
                    Vector3 spawnPosition = new Vector3(transform.position.x+2f,transform.position.y,transform.position.z-2f);
                    if(spawnPosition.z<0){
                             spawnPosition = new Vector3(transform.position.x+2f,transform.position.y,transform.position.z+2f);
                            Instantiate(BishopLeft,spawnPosition,transform.rotation);
                        }else
                    Instantiate(BishopRight,spawnPosition,transform.rotation);
                }
                bishoptxtCD.gameObject.SetActive(true);
                bishopCastCD=2.0f;
                bishoptxtCD.text = Mathf.RoundToInt(bishopCastCD).ToString();
                bishopImageCD.fillAmount = 1.0f;
    }
}

public void KnightSpawn(){
    if(knightCastCD<=0){
        int check = Random.Range(0,2);
                 
                if(check==0){
                    Vector3 spawnPosition = new Vector3(transform.position.x+4f,transform.position.y,transform.position.z+2f);
                    if(spawnPosition.z>14){
                             spawnPosition = new Vector3(transform.position.x+2f,transform.position.y,transform.position.z-2f);
                            Instantiate(KnightRight,spawnPosition,transform.rotation);
                        }else
                    Instantiate(KnightLeft,spawnPosition,transform.rotation);
                }
                else if(check==1){
                    Vector3 spawnPosition = new Vector3(transform.position.x+4f,transform.position.y,transform.position.z-2f);
                    if(spawnPosition.z<0){
                             spawnPosition = new Vector3(transform.position.x+2f,transform.position.y,transform.position.z+2f);
                            Instantiate(KnightLeft,spawnPosition,transform.rotation);
                        }else
                    Instantiate(KnightRight,spawnPosition,transform.rotation);
                }
                knighttxtCD.gameObject.SetActive(true);
                knightCastCD = 1.8f;
                knighttxtCD.text = Mathf.RoundToInt(knightCastCD).ToString();
                knightImageCD.fillAmount = 1.0f;
                
}
}

public void RookSpawn(){
    if(rookCastCD<=0){
        Vector3 spawnPosition = new Vector3(transform.position.x+2f,transform.position.y,transform.position.z);
                Instantiate(Rook,spawnPosition,transform.rotation);

                rooktxtCD.gameObject.SetActive(true);
                rookCastCD=2.5f;
                rooktxtCD.text = Mathf.RoundToInt(rookCastCD).ToString();
                rookImageCD.fillAmount = 1.0f;
    }
}

public void PawnSpawn(){
    if(pawnCastCD<=0){
        Vector3 spawnPosition = new Vector3(transform.position.x+2f,transform.position.y,transform.position.z);
                Instantiate(Pawn,spawnPosition,transform.rotation);

                pawntxtCD.gameObject.SetActive(true);
                pawnCastCD = 1.4f;
                pawntxtCD.text = Mathf.RoundToInt(pawnCastCD).ToString();
                pawnImageCD.fillAmount = 1.0f;
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
    if(other.gameObject.tag=="black"){
            Debug.Log("Player hit");
            Destroy(other.gameObject);
            LossHP(1);
        }
}

public void LossHP(int HP){
    Health-=HP;
    hpBar.fillAmount = (float)Health/2.0f;
}

public void AddHP(int HP){
    Health+=HP;
}
   

    
}
