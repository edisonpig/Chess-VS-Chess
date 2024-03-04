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
        if(GameObject.Find("King B Variant").GetComponent<B_AiMovement>().lighting){
            rb.velocity = direction*2.3f;
           }else{
        rb.velocity = direction * 1.8f;
           }
        timer=0;
        }else{
            timer+=Time.deltaTime;
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
