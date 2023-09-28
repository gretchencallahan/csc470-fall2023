using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    public GameObject cell;
    
    // Start is called before the first frame update
    void Start()
    {
        generateBoard(10, 10);
    }

    void generateBoard(int n, int m){
    
        for(int x = 0; x < n; x++){
            for(int z = 0; z < m; z++){
                
                Vector3 pos = transform.position;
                float boardSpacing = 1.03f;
                pos.x = pos.x + x * boardSpacing;
                pos.z = pos.z + z * boardSpacing;
                GameObject cellObject = Instantiate(cell, pos, Quaternion.identity);   
                
    }}}
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
