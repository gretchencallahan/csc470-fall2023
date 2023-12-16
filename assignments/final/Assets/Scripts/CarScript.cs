using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("car"))
        {
            Destroy(this.gameObject);
        }
        if (other.CompareTag("Cat"))
        {
            GameManagerScript.SharedInstance.endGame = true;
        }
    }
}
