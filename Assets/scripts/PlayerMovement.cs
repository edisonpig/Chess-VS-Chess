using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool movementOnGoing = true;
    
    public Vector3 movement;
    public Vector3 desiredPosition;
    public Vector3 smoothPosition;
    
    public float smoothSpeed;

    [SerializeField] public GameObject Pawn=null;
    [SerializeField] public GameObject BishopLeft=null;

    [SerializeField] public GameObject BishopRight=null;
    [SerializeField] public GameObject KnightLeft=null;
    [SerializeField] public GameObject KnightRight=null;
    [SerializeField] public GameObject Rook=null;


    public float castCD = 0f;
    public float KnightCastCD = 1.8f;
    public float BishopCastCD = 2.0f;
    public float RookCastCD = 2.5f;
    public float PawnCastCD = 1.4f;



    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        if(castCD>0.3f){
        PlayerSpawn();
        }else{
            castCD+=Time.deltaTime;
        }
        BishopCastCD-=Time.deltaTime;
        KnightCastCD-=Time.deltaTime;
        PawnCastCD-=Time.deltaTime;
        RookCastCD-=Time.deltaTime;
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
        
        movementOnGoing = true;
        }
    }

    private void PlayerSpawn(){

            if(Input.GetKeyDown(KeyCode.Q)&&BishopCastCD<=0){
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
                BishopCastCD=2.0f;
            }
            
             if(Input.GetKeyDown(KeyCode.W)&&KnightCastCD<=0){
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
                KnightCastCD = 1.8f;

            }
             if(Input.GetKeyDown(KeyCode.E)&&RookCastCD<=0){
                Vector3 spawnPosition = new Vector3(transform.position.x+2f,transform.position.y,transform.position.z);
                Instantiate(Rook,spawnPosition,transform.rotation);
                RookCastCD=2.5f;
            }
             if(Input.GetKeyDown(KeyCode.Space)){
                Vector3 spawnPosition = new Vector3(transform.position.x+2f,transform.position.y,transform.position.z);
                Instantiate(Pawn,spawnPosition,transform.rotation);
                PawnCastCD = 1.4f;
            }
        }
    

   

    
}
