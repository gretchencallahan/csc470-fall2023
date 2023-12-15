using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        boundMap();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("car"))
        {
            GameManagerScript.SharedInstance.endGame = true;
        }
    }

    void boundMap() {
        if(this.transform.position.x < -99)
        {
            this.transform.position = new Vector3(-99, this.transform.position.y, this.transform.position.z);
        }
        else if(this.transform.position.x > 99)
        {
            this.transform.position = new Vector3(99, this.transform.position.y, this.transform.position.z);
        }
        else if(this.transform.position.z < -199)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -199);
        }
        else if(this.transform.position.z > 199)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -99);
        }
    }

}
