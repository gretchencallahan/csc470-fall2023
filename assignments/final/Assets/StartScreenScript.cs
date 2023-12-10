using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenScript : MonoBehaviour
{   
    // Start is called before the first frame update
    void Start()
    {
        // not the best practice
        //DontDestroyOnLoad(this);
        
        
        //StartButtonPressed();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void StartButtonPressed(){
        // i don't have a clickcount thing in my scene just including this for my own reference later
        //PlayerPrefs.SetInt("clickCount", clickCount);
        
        SceneManager.LoadScene("SampleScene");
    
    }
}
