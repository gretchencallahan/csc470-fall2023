using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreScript : MonoBehaviour
{
    public TMP_Text endText;

    // Start is called before the first frame update
    void Start()
    {
        int score = PlayerPrefs.GetInt("highscore");
        endText.text = "You saved " + score + " kitties!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
