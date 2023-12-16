using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("car"))
        {
            GameManagerScript.SharedInstance.endGame = true;
        }
        else if (other.CompareTag("newSection"))
        {
            GameManagerScript.SharedInstance.generateNewSection();
        }
    }


}
