using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameScript : MonoBehaviour
{

    public GameObject panel;


    public void startGame()
    {
        panel.SetActive(false);
    }
}
