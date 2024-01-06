using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random=UnityEngine.Random;


public class B_RookMove : MonoBehaviour
{
    public float timer;

    public Vector3 movement;

    [SerializeField] private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    if(timer>0.5f){
            
                movement = new Vector3(transform.position.x-2f,transform.position.y,transform.position.z);

            
            if(movement.x<0){
                Destroy(gameObject);
            
            }
            Vector3 direction = (movement - transform.position).normalized;
        rb.velocity = direction * 1.8f;
        timer=0;
        }else{
            timer+=Time.deltaTime;
        }


    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="black"){
            Destroy(gameObject);
        }
    }
}
