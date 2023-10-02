// Gretchen Callahan
// Game Programming
// 03_emergence

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour
{
    // this is a section for public global variables I used throughout this project
    public bool alive = false; // keeping track of a cell's state
    public bool previouslyDead = false; // keeping track of a previous death state for a given cell
    public int x, z; // x and z values to use for placing each cell in it's spot on the gameboard
    public int aliveNeighbors; // a variable to keep track of a cell's alive neighbors at a given time
    public Color livingColor; // a color for living cells (that haven't been previously dead)
    public Color deadColor; // a color for dead cells
    Renderer cellRend; // a variable for the cells' renderers

    // Start is called before the first frame update
    void Start()
    {   
        // accessing each cell's renderer and storing it here
        cellRend = gameObject.GetComponentInChildren<Renderer>();
        // changing the color of cells at the start of the game to see alive vs dead cells before the games first iteration
        changeColor();  
    }

    // a function to change a cell's color
    public void changeColor(){
        // if it's alive go down this conditional
        if(alive){ 
            if (previouslyDead){
            // this is a new rule I created to change the color of an alive cell if it has been previously dead
            // i randomly chose the numbers 23, 67, and 5 to make the colors more interesting
            // to make the colors more fun I also used the sin function to have them bounce back and forth on the color spectrum
                float num = Random.value * 23;
                float hue = Mathf.Abs(Mathf.Sin(num / 67 * 5));
                cellRend.material.color = Color.HSVToRGB(hue % 2f, 1f, 0.8f);
            }
            else{
            // if the cell hasn't died previously give it the regular color for living cells
            cellRend.material.color = livingColor; 
            }
        }
        // if the cell isn't alive go down this conditional and give it the color for dead cells
        else{ 
            cellRend.material.color = deadColor; 
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

}
