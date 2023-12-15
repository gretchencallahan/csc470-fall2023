using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenScript : MonoBehaviour
{
    public GameObject audioObject;

    // Start is called before the first frame update
    void Start()
    {
        // not the best practice i k now
        DontDestroyOnLoad(audioObject);

        PlayerPrefs.SetInt("highscore", 0);
    }
    
    public void StartButtonPressed(){
        
        SceneManager.LoadScene("ControlsScene");
    
    }
}
