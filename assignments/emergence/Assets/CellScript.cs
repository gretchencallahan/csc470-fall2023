using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour
{
    public bool alive = false;
    public int x, z;
    public int aliveNeighbors;
    public Color livingColor;
    public Color deadColor;
    Renderer cellRend;
    
    // Start is called before the first frame update
    void Start()
    {
        cellRend = gameObject.GetComponentInChildren<Renderer>();
        changeColor();  
    }

    public void changeColor(){
        if(alive){ 
            cellRend.material.color = livingColor; 
        }
        else{ 
            cellRend.material.color = deadColor; 
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

}
