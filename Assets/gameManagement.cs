using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManagement : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TryAgain(){
        SceneManager.LoadScene(1);
        Time.timeScale=1f;
        
    }

    public void MainMenu(){
        SceneManager.LoadScene(0);
        Time.timeScale=1f;
    }
}
