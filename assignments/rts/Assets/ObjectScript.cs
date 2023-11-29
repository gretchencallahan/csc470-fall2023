using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    public bool selected = false;
    //int clicks = 0;
    public GameObject thisObj;
    
    // Start is called before the first frame update
    void Start()
    {
        //thisObj = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //private void OnMouseDown()
    //{
        
        
        //if(clicks % 2 == 0){
            //ObjectScript selectedObj = GameManager.SharedInstance.SelectObj(this);
            //selectedObj.selected = true;
            //if(selectedObj.selected == true){
                //if(Input.GetKey(KeyCode.Q)){
                    //selectedObj.transform.localEulerAngles = new Vector3 (0, 90, 0);
                //}
                //if(Input.GetKey(KeyCode.E)){
                    //selectedObj.transform.localEulerAngles = new Vector3 (0, -90, 0);
                //}
            //}
        //}
        
        //clicks += 1;
    //} 
}
