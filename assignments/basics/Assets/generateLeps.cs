using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateLeps : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        generateLeprechauns();
    }

    public GameObject leprechauns;
    public void generateLeprechauns(){
        //float x = -2;
        //float y = 0;
        //float z = -2;
        //Vector3 posi = new Vector3(x, y, z);
        
        for(int x = -2; x < 4; x++){
            GameObject lepObj = Instantiate(leprechauns, new Vector3(x, 0, -2), Quaternion.identity);    
        }
        for(int z = -2; z < 4; z++){
            GameObject lepObj = Instantiate(leprechauns, new Vector3(4, 0, z), Quaternion.identity);
        }
    
    
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
