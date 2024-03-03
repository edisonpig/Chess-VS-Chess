using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random=UnityEngine.Random;

public class BishopRight : MonoBehaviour
{
    public float timer;

    public bool prevmovement = false;
    
    public Vector3 movement;
    public bool arrivePoint = true;

    public bool wallCheck=true;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private GameObject Effect;
    [SerializeField] private GameObject CooldownBuffadd;
    [SerializeField] private GameObject HPadd;
    [SerializeField] private GameObject Lightningadd;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
       /* if(timer>0.6f){
            movement = new Vector3(transform.position.x+2f,transform.position.y,transform.position.z-2f);
            if(transform.position.z<=1||prevmovement){
               movement = new Vector3(transform.position.x+2f,transform.position.y,transform.position.z+2f);
               prevmovement=true; 
               

               
            }
            if(transform.position.x>=13){
                Destroy(gameObject);
            
            }
            transform.position=movement;
            timer=0;
        }
        else{
            timer+=Time.deltaTime;
        }*/
        if(timer>0.3f &&arrivePoint){
        movement = new Vector3(transform.position.x+2f,transform.position.y,transform.position.z-2f);
            if(transform.position.z<0||prevmovement){
                Debug.Log("went wrong1.1 "+transform.position.z +":z + "+movement.z );
               movement = new Vector3((float)Math.Round((double)transform.position.x)+2f,transform.position.y,(float)Math.Round((double)transform.position.z)+2f);
               prevmovement=true;
               Debug.Log("went wrong1 "+transform.position.z +":z + "+movement.z );
                
            }if((int)Math.Floor(movement.z)<-1&&wallCheck){
                Debug.Log(movement.z);
                Debug.Log(transform.position.z);
                movement =new Vector3((float)(int)Math.Round((double)movement.x),0,(float)(int)Math.Round((double)-movement.z));
                wallCheck=false;
                prevmovement=true;
                Debug.Log("wallCheck");
            }
           /* if(transform.position.z%1==0){ }else{
                Debug.Log("went wrong2.1 "+transform.position.z +":z + "+movement.z );
            movement = new Vector3 ((float)Math.Round((double)movement.x/2)*2,0,(float)Math.Round((double)movement.z/2)*2);
            Debug.Log("went wrong2 "+transform.position.z +":z + "+movement.z );
            }*/
            
            Vector3 direction = (movement - transform.position).normalized;
            Debug.Log("x: "+ movement.x+ " z: +"+movement.z);

        if(GameObject.Find("King W Variant").GetComponent<PlayerMovement>().lighting){
            rb.velocity = direction*2.3f;
           }else{
        rb.velocity = direction * 1.8f;
           }

        
        
        timer=0;
        
        
        }else{
            timer+=Time.deltaTime;
        }
        if((Math.Round((double)movement.x,1)==Math.Round((double)transform.position.x,1))&&(Math.Round((double)movement.z,1)==Math.Round((double)transform.position.z,1))){
            transform.position=movement;
            arrivePoint= true;
            
            Debug.Log("Requirements met bishopright");
        }else if(movement.x!=0f&&movement.z!=0f){
            arrivePoint=false;
        }
if(transform.position.x>=14){
                Destroy(gameObject);
            
            }
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="black"){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
         if(other.gameObject.tag=="black"){
            Debug.Log("Bishop right hit");
            Destroy(other.gameObject);
            GameObject cloneW = Instantiate(Effect, transform.position, transform.rotation);
            Destroy(cloneW,1f);
            int check = Random.Range(0,10);
            if(check<2){
                Instantiate(CooldownBuffadd, new Vector3((float)Math.Round((double)transform.position.x,0),0.91f,(float)Math.Round((double)transform.position.z,0)), transform.rotation);
            }else if(check<4){
                Instantiate(HPadd, new Vector3((float)Math.Round((double)transform.position.x,0),0.91f,(float)Math.Round((double)transform.position.z,0)), transform.rotation);
            }else if(check<6){
                Instantiate(Lightningadd, new Vector3((float)Math.Round((double)transform.position.x,0),0.91f,(float)Math.Round((double)transform.position.z,0)), Quaternion.Euler(90,0,0));
            }
            Destroy(gameObject);
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
        


}
}
