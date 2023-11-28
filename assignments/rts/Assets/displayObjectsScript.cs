using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayObjectsScript : MonoBehaviour
{
    public GameObject objectsPanel;
    int objectClicks = 0;
    

    public void showObjects(){
        if ((objectsPanel != null) & (objectClicks % 2 == 0)){
            objectsPanel.SetActive(true);
            objectClicks += 1;
        }
        else if(objectClicks % 2 == 1){
            objectsPanel.SetActive(false);
            objectClicks += 1;
        
        }
    }

}
