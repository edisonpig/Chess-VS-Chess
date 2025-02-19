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

    public static int Health = 3;
    public bool movementOnGoing = true;
    public Vector3 movement;
    public Vector3 desiredPosition;
    public Vector3 smoothPosition;
    public float smoothSpeed;


[Header("Chess")]
    [SerializeField] private GameObject Pawn=null;
    public float pawnCastCD = 7f;
    public static float pawnRecastCD = 7f;
    public float pawnOriginalCastCD = 7f;
    [SerializeField] private GameObject BishopLeft=null;
    [SerializeField] private GameObject BishopRight=null;
    public float bishopCastCD = 4.0f;
    public static float bishopRecastCD = 4.0f;
    public float bishopOriginalCastCD = 4.0f;
    [SerializeField] private GameObject KnightLeft=null;
    [SerializeField] private GameObject KnightRight=null;
    public float knightCastCD = 3f;
    public static float knightRecastCD = 3f;
    public float knightOriginalCastCD = 3f;
    [SerializeField] private GameObject Rook=null;
    public float rookCastCD = 3.5f;
    public static float rookRecastCD = 3.5f;
    public float rookOriginalCastCD = 3.5f;
    [Header("Collectives")]
    //CooldownBuff = hourglass --> cooldown decrease
    //strength = gem red --> chess hp +1
    //lighting = lighting --> chess faster
    public float CooldownBuffCD=30f;
    public float lightingCD = 20f;

    public bool lighting = false;
    [SerializeField] private GameObject CooldownBuffIcon;
    [SerializeField] private GameObject LightingIcon;
    public int CooldownBuffTimes = 0;

    [SerializeField] private GameObject Effect;
    [SerializeField] private  GameObject CooldownBuffEffect;
    [SerializeField] private  GameObject lightingEffect;



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
    [SerializeField] private GameObject AIWinText;
    [SerializeField] private GameObject EndUI;


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
        if(CooldownBuffCD<30f){
            CooldownBuffCD+=Time.deltaTime;
            
        }else if(CooldownBuffCD>30f){
            CooldownDegrade();
        }
        if(lighting){
            lightingCD-=Time.deltaTime;
        }
        if(lightingCD<0){
            lightingEffect.SetActive(false);
            LightingIcon.SetActive(false);
            lighting=false;
            lightingCD=20f;
        }

    }
    void FixedUpdate()
    {
      HealthCheck();  
    }

private void HealthCheck(){
    if(Health<=0){
        Debug.Log("health0 - player");
        Time.timeScale=0f;
        Health=3;
        EndUI.SetActive(true);
        AIWinText.SetActive(true);
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

            if(Input.GetKeyDown(KeyCode.I)){
                BishopSpawn();
            }
            
             if(Input.GetKeyDown(KeyCode.O)){
                KnightSpawn();

            }
             if(Input.GetKeyDown(KeyCode.P)){
                RookSpawn();
                
            }
             if(Input.GetKeyDown(KeyCode.L)){
                PawnSpawn();
                
            }
        }


    void CoolDown(){
        //Bishop

        if(bishopCastCD>=0){
            bishopCastCD-=Time.deltaTime;
            bishoptxtCD.text = Mathf.RoundToInt(bishopCastCD).ToString();
            bishopImageCD.fillAmount = bishopCastCD / bishopRecastCD;
        } else{
            bishoptxtCD.gameObject.SetActive(false);
            bishopImageCD.fillAmount = 0.0f;
        }


        //Knight
        if(knightCastCD>=0){
            knightCastCD-=Time.deltaTime;
            knighttxtCD.text = Mathf.RoundToInt(knightCastCD).ToString();
            knightImageCD.fillAmount = knightCastCD / knightRecastCD;
        } else{
            knighttxtCD.gameObject.SetActive(false);
            knightImageCD.fillAmount = 0.0f;
        }


        //Pawn
        if(pawnCastCD>=0){
            pawnCastCD-=Time.deltaTime;
            pawntxtCD.text = Mathf.RoundToInt(pawnCastCD).ToString();
            pawnImageCD.fillAmount = pawnCastCD / pawnRecastCD;
        } else{
            pawntxtCD.gameObject.SetActive(false);
            pawnImageCD.fillAmount = 0.0f;
        }

        


        //Rook

        if(rookCastCD>=0){
            rookCastCD-=Time.deltaTime;
            rooktxtCD.text = Mathf.RoundToInt(rookCastCD).ToString();
            rookImageCD.fillAmount = rookCastCD / rookRecastCD;
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
                bishopCastCD=bishopRecastCD;
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
                knightCastCD = knightRecastCD;
                knighttxtCD.text = Mathf.RoundToInt(knightCastCD).ToString();
                knightImageCD.fillAmount = 1.0f;
                
}
}

public void RookSpawn(){
    if(rookCastCD<=0){
        Vector3 spawnPosition = new Vector3(transform.position.x+2f,transform.position.y,transform.position.z);
                Instantiate(Rook,spawnPosition,transform.rotation);

                rooktxtCD.gameObject.SetActive(true);
                rookCastCD=rookRecastCD;
                rooktxtCD.text = Mathf.RoundToInt(rookCastCD).ToString();
                rookImageCD.fillAmount = 1.0f;
    }
}

public void PawnSpawn(){
    if(pawnCastCD<=0){
        Vector3 spawnPosition = new Vector3(transform.position.x+2f,transform.position.y,transform.position.z);
                Instantiate(Pawn,spawnPosition,transform.rotation);

                pawntxtCD.gameObject.SetActive(true);
                pawnCastCD = pawnRecastCD;
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
            GameObject cloneW = Instantiate(Effect, transform.position, transform.rotation);
            Destroy(cloneW,1f);
            LossHP(1);
        }
    if(other.gameObject.tag == "hourglass"){
            Debug.Log("hourglass cd buff");
        GameObject.Find("King W Variant").GetComponent<PlayerMovement>().CooldownUpgrade();
        Destroy(other.gameObject);
    }
    if(other.gameObject.tag == "HP"){
        Debug.Log("addhp");
        GameObject.Find("King W Variant").GetComponent<PlayerMovement>().AddHP(1);
        Destroy(other.gameObject);
    }
    if(other.gameObject.tag == "Lightning"){
        Debug.Log("lightning");
        GameObject.Find("King W Variant").GetComponent<PlayerMovement>().LightingOn();
        Destroy(other.gameObject);
    }
    if(other.gameObject.tag=="Question"){
        Debug.Log("lightning");
        GameObject.Find("King W Variant").GetComponent<PlayerMovement>().QuestionOn();
        Destroy(other.gameObject);
    }
}

public void LossHP(int HP){
    Health-=HP;
    hpBar.fillAmount = (float)Health/3.0f;
}


public void AddHP(int HP){
    Health+=HP;
    if(Health>3){
        Health=3;
    }
    hpBar.fillAmount = (float)Health/3.0f;
}

public void CooldownUpgrade(){
    if(CooldownBuffTimes<1){
    
        CooldownBuffTimes++;
pawnRecastCD*=0.8f;
rookRecastCD*=0.8f;
bishopRecastCD*=0.8f;
knightRecastCD*=0.8f;
CooldownBuffCD=0f;
CooldownBuffEffect.SetActive(true);
CooldownBuffIcon.SetActive(true);
    }
}

public void CooldownDegrade(){
    pawnRecastCD=pawnOriginalCastCD;
rookRecastCD=rookOriginalCastCD;
bishopRecastCD=bishopOriginalCastCD;
knightRecastCD=knightOriginalCastCD;
CooldownBuffEffect.SetActive(false);
CooldownBuffIcon.SetActive(false);
CooldownBuffCD=30f;
CooldownBuffTimes--;
}

public void LightingOn(){
    lightingEffect.SetActive(true);
    LightingIcon.SetActive(true);
    lighting=true;
}

public void QuestionOn(){
Debug.Log("Random player");
}

   

    
}
