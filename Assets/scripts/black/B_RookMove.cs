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
    [SerializeField] private GameObject RookMovePlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    if(timer>0.5f){
            
                movement = new Vector3(transform.position.x-2f,transform.position.y,transform.position.z);

            
            if(transform.position.x<0){
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
    if(other.gameObject.tag == "Skull"){
        Debug.Log("Skull");

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
    
    if(other.gameObject.tag=="Curse"){
         rb.velocity = Vector3.zero;
        //transform.position = Vector3.MoveTowards(transform.position,other.gameObject.transform.position,1.4f*Time.deltaTime);
        while (other.gameObject.transform.position !=transform.position){
            transform.Translate((other.gameObject.transform.position.x-transform.position.x)*0.1f,0,(other.gameObject.transform.position.z-transform.position.z)*0.1f);
        }
         Instantiate(RookMovePlayer,transform.position,transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);

    }
    if(other.gameObject.tag=="Split"){
        rb.velocity = Vector3.zero;
            Vector3 spawnPt1 = transform.position + new Vector3(2,0,2);
            Vector3 spawnPt2 = transform.position + new Vector3(2,0,-2);

        Instantiate(gameObject,spawnPt1,transform.rotation);
        Instantiate(gameObject,spawnPt2,transform.rotation);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

}
}
