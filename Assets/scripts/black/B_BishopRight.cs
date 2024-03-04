using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random=UnityEngine.Random;


public class B_BishopRight : MonoBehaviour
{
   public float timer;
    public bool prevmovement = false;
    
    public Vector3 movement;
    public bool arrivePoint = true;

    [SerializeField] private Rigidbody rb;

    
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
            
                movement = new Vector3(transform.position.x-2f,transform.position.y,transform.position.z+2f);
            if(transform.position.z>=13||prevmovement){
               movement = new Vector3(transform.position.x-2f,transform.position.y,transform.position.z-2f);
               Debug.Log("turn");
                prevmovement=true;
            }
            movement = new Vector3 ((float)Math.Round((double)movement.x,2),0,(float)Math.Round((double)movement.z,2));
            
            Vector3 direction = (movement - transform.position).normalized;
        if(GameObject.Find("King B Variant").GetComponent<B_AiMovement>().lighting){
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
            
            Debug.Log("Requirements met B_bishopleft");
        }else if(movement.x!=0f&&movement.z!=0f){
            arrivePoint=false;
        }
if(transform.position.x<0){
                Destroy(gameObject);
            
            }

        
        
    
    }
  
void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "hourglass"){
            Debug.Log("hourglass cd buff");
        GameObject.Find("King B Variant").GetComponent<B_AiMovement>().CooldownUpgrade();
        Destroy(other.gameObject);
    }
    if(other.gameObject.tag == "HP"){
        Debug.Log("addhp");
        GameObject.Find("King B Variant").GetComponent<B_AiMovement>().AddHP(1);
        Destroy(other.gameObject);
    }
    if(other.gameObject.tag == "Lightning"){
        Debug.Log("lightning");
        GameObject.Find("King B Variant").GetComponent<B_AiMovement>().LightingOn();
        Destroy(other.gameObject);
    }
    if(other.gameObject.tag=="Question"){
        Debug.Log("lightning");
        GameObject.Find("King B Variant").GetComponent<PlayerMovement>().QuestionOn();
        Destroy(other.gameObject);
    }
   
}

}