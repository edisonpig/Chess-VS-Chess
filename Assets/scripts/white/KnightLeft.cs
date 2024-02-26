using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random=UnityEngine.Random;

public class KnightLeft : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer;

   
    public Vector3 movement;
    public int CountTimes = 0;

    [SerializeField] private Rigidbody rb;

    public bool arrivePoint = true;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer>0.8f&&arrivePoint){
            

            if(CountTimes==0){
                int check = Random.Range(0,2);
                if(transform.position.x>11.5){
                    check=1;
                }
                if(check==0){
                    movement = new Vector3(transform.position.x+4f,transform.position.y,transform.position.z+2f);
                    if(movement.z>14){
                        movement = new Vector3(transform.position.x+4f,transform.position.y,transform.position.z-2f);
                    }
                }else{
                   movement = new Vector3(transform.position.x+2f,transform.position.y,transform.position.z+4f); 
                   if(movement.z>14){
                        movement = new Vector3(transform.position.x+2f,transform.position.y,transform.position.z-4f);
                    }
                }
                CountTimes++;
                
            
            }
            else if(CountTimes==1){
                 int check = Random.Range(0,2);
                 if(transform.position.x>12){
                    check=1;
                }
                if(check==0){
                    movement = new Vector3(transform.position.x+4f,transform.position.y,transform.position.z-2f);
                    if(movement.z<0){
                        movement = new Vector3(transform.position.x+4f,transform.position.y,transform.position.z+2f);
                    }
                }else{
                   movement = new Vector3(transform.position.x+2f,transform.position.y,transform.position.z-4f); 
                   if(movement.z<0){
                        movement = new Vector3(transform.position.x+2f,transform.position.y,transform.position.z+4f);
                    }
                }
                 CountTimes--;
                  
            }
            
            movement = new Vector3 ((float)Math.Round((double)movement.x),0,(float)Math.Round((double)movement.z));
            
            Vector3 direction = (movement - transform.position).normalized;
        rb.velocity = direction * 1.8f;
        
            timer=0;
            
        }
        else{
            timer+=Time.deltaTime;
        }
        if(((int)Math.Round((double)movement.x,2)==(int)Math.Round((double)transform.position.x,2))&&((int)Math.Round((double)movement.z,2)==(int)Math.Round((double)transform.position.z,2))){
            transform.position=movement;
            arrivePoint= true;
            
            Debug.Log("Requirements met knightleft");
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
            Debug.Log("Knight Left hit");
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        


}
}
