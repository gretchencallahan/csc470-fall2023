using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walking : MonoBehaviour
{
    // Start is called before the first frame update
    void Start(){
        
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)){
            transform.position += new Vector3(2, 0, 0) * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)){
            transform.position += new Vector3(-2, 0, 0) * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
            transform.position += new Vector3(0, 0, 2) * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
            transform.position += new Vector3(0, 0, -2) * Time.deltaTime;
        }
    }
}
