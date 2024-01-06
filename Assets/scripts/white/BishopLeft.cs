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
        rb.velocity = direction * 1.8f;
        
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
            Destroy(gameObject);
        }
    }


}
