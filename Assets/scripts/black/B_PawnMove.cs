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

    
}
