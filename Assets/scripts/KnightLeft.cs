using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightLeft : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer;

   
    public Vector3 movement;
    public int CountTimes = 1;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer>0.8f){
            

            if(CountTimes==0){
                int check = Random.Range(0,2);
                if(transform.position.x>11){
                    check=1;
                }
                if(check==0){
                    movement = new Vector3(transform.position.x+4f,transform.position.y,transform.position.z+2f);
                    if(movement.z>13){
                        movement = new Vector3(transform.position.x+4f,transform.position.y,transform.position.z-2f);
                    }
                }else{
                   movement = new Vector3(transform.position.x+2f,transform.position.y,transform.position.z+4f); 
                   if(movement.z>13){
                        movement = new Vector3(transform.position.x+2f,transform.position.y,transform.position.z-4f);
                    }
                }
                CountTimes++;
                
            
            }
            else if(CountTimes==1){
                 int check = Random.Range(0,2);
                 if(transform.position.x>11){
                    check=1;
                }
                if(check==0){
                    movement = new Vector3(transform.position.x+4f,transform.position.y,transform.position.z-2f);
                    if(movement.z<1){
                        movement = new Vector3(transform.position.x+4f,transform.position.y,transform.position.z+2f);
                    }
                }else{
                   movement = new Vector3(transform.position.x+2f,transform.position.y,transform.position.z-4f); 
                   if(movement.z<1){
                        movement = new Vector3(transform.position.x+2f,transform.position.y,transform.position.z+4f);
                    }
                }
                 CountTimes--;
                  
            }
            if(movement.x>15){
                Destroy(gameObject);
            
            }
            transform.position=movement;
            timer=0;
            
        }
        else{
            timer+=Time.deltaTime;
        }

        
    }
    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
