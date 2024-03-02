using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random=UnityEngine.Random;

public class BishopLeft : MonoBehaviour
{
    public float timer;
    public bool prevmovement = false;
    
    public Vector3 movement;
    public bool arrivePoint = true;

    
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
            movement = new Vector3(transform.position.x+2f,transform.position.y,transform.position.z+2f);
            if(transform.position.z>=13||prevmovement){
               movement = new Vector3(transform.position.x+2f,transform.position.y,transform.position.z-2f);
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
        }
        */
        
        if(timer>0.4f&&arrivePoint){
            
                movement = new Vector3(transform.position.x+2f,transform.position.y,transform.position.z+2f);
            if(transform.position.z>=13||prevmovement){
               movement = new Vector3(transform.position.x+2f,transform.position.y,transform.position.z-2f);
                prevmovement=true;
            }
            movement = new Vector3 ((float)Math.Round((double)movement.x,2),0,(float)Math.Round((double)movement.z,2));
            
            Vector3 direction = (movement - transform.position).normalized;
        if(GameObject.Find("King W Variant").GetComponent<PlayerMovement>().lighting){
            rb.velocity = direction*2.3f;
           }else{
        rb.velocity = direction * 1.8f;
           }
        
        timer=0;
        
        }else{
            timer+=Time.deltaTime;
        }
        if(((int)Math.Round((double)movement.x,2)==(int)Math.Round((double)transform.position.x,2))&&((int)Math.Round((double)movement.z,2)==(int)Math.Round((double)transform.position.z,2))){
            transform.position=movement;
            arrivePoint= true;
            
            Debug.Log("Requirements met bishopleft");
        }else if(movement.x!=0f&&movement.z!=0f){
            arrivePoint=false;
        }
if(transform.position.x>=14){
                Destroy(gameObject);
            
            }

        
        
    
    }

    void OnTriggerEnter(Collider other)
    {
         if(other.gameObject.tag=="black"){
            Debug.Log("Bishop Left hit");
            Destroy(other.gameObject);
            GameObject cloneW = Instantiate(Effect, transform.position, transform.rotation);
            Destroy(cloneW,1f);
            int check = Random.Range(0,10);
            if(check<2){
                Instantiate(CooldownBuffadd, new Vector3((float)Math.Round((double)transform.position.x,0),0.91f,(float)Math.Round((double)transform.position.z,0)), transform.rotation);
            }else if(check<4){
                Instantiate(HPadd, new Vector3((float)Math.Round((double)transform.position.x,0),0.91f,(float)Math.Round((double)transform.position.z,0)), transform.rotation);
            }else if(check<6){
                Instantiate(Lightningadd, new Vector3((float)Math.Round((double)transform.position.x,0),0.91f,(float)Math.Round((double)transform.position.z,0)), transform.rotation);
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
