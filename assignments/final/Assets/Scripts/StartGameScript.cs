using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour
{

    public GameObject panel;


    public void startGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
