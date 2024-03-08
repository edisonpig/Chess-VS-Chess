using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random=UnityEngine.Random;

public class QuestionMarkSpawn : MonoBehaviour
{

    [SerializeField] private GameObject CurseField;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        int effectChoose = Random.Range(0,1);
        int genNumber = Random.Range(1,4);
        if(effectChoose==0){
            for (int i=0;i<=genNumber;i++){
                int RandomX = Random.Range(1,4)*2 +4;
                int RandomZ = Random.Range(0,8)*2;
                Vector3 GenPos = new Vector3((float)RandomX,0f,(float)RandomZ);
                Instantiate(CurseField,GenPos,Quaternion.Euler(0f,0f,0f));

            }
            
        }
        Destroy(gameObject);
    }
}
