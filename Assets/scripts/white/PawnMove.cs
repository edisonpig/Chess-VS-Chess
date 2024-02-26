using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnMove : MonoBehaviour
{
    public float countDown = 6.0f;
    
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
         if(other.gameObject.tag=="black"){
            Debug.Log("pawn hit");
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        


}
}
