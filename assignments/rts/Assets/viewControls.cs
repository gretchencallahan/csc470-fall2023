using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viewControls : MonoBehaviour
{
    public GameObject controlsPanel;
    int controlClicks = 0;
    
    public void openControls(){
        if ((controlsPanel != null) & (controlClicks % 2 == 0)){
            controlsPanel.SetActive(true);
            controlClicks += 1;
        }
        else if(controlClicks % 2 == 1){
            controlsPanel.SetActive(false);
            controlClicks += 1;
        }
        
    }
    
}
