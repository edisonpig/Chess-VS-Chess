using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopLeft : MonoBehaviour
{
    public float timer;

    public bool prevmovement = false;
    public Vector3 movement;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer>0.6f){
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

        
    }
    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
