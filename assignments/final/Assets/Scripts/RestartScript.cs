using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{

    public void playAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void dontPlayAgain()
    {
        SceneManager.LoadScene("HighScoreScene");
    }
}
