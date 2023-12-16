using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RookMove : MonoBehaviour
{
    public float timer;
    public Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer>0.5f){
            movement = new Vector3(transform.position.x+2f,transform.position.y,transform.position.z);
        
         if(movement.x>15){
                Destroy(gameObject);
            
            }
            transform.position=movement;
            timer=0;
            }else{
            timer+=Time.deltaTime;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
