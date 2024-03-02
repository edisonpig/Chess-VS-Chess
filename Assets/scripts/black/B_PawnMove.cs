using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random=UnityEngine.Random;


public class B_PawnMove : MonoBehaviour
{
    public float countDown=6f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(countDown<0){
            Destroy(gameObject);
        }else{
            countDown-=Time.deltaTime;
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
   
}
}
