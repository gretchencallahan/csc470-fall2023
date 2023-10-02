// Gretchen Callahan
// Game Programming
// 03_emergence

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOfLife : MonoBehaviour
{   
    // a section for public global variables i used throughout this project
    // creating a cell game object
    public GameObject cell;
    // creating a 2d array of cell scripts to use (called cells)
    public CellScript[,] cells;
    // an integer value for the length of the original board
        // now if you want to change the length you have to do it in unity
    public int boardLength = 40;
    
    // Start is called before the first frame update
    void Start()
    {   
        // generate the board for each game (i made it a square)
        generateBoard(boardLength, boardLength);
    }

    // a function for generating the gameboards
    void generateBoard(int m, int n){
        
        // make the cells array of the size m x n
        cells = new CellScript[m, n];

        // using nested for loops instantiate the cells
        for(int x = 0; x < m; x++){
            for(int z = 0; z < n; z++){

                // use the cells' transform position to find where they are in unity
                Vector3 pos = transform.position;
                // a float value for how far apart the board cells should be spaces
                    // right now it's 1 because I liked the way it looked like an 8bit game
                float boardSpacing = 1f;
                // update the cells' x and y positions using the indices from the loops
                pos.x = pos.x + x * boardSpacing;
                pos.z = pos.z + z * boardSpacing;
                
                // create a gameobject for the cells and instantiate them using the cell prefab, pos vairable, and it's transform rotation (currently none)
                GameObject cellObject = Instantiate(cell, pos, transform.rotation);
                // for each cell access it's CellScript component
                cells[x, z] = cellObject.GetComponent<CellScript>();
                // then using a 50% probability of alive vs dead update the cells' state variable
                cells[x, z].alive = (Random.value < 0.5f);
                // then update the cells' x and z variables
                cells[x, z].x = x;
                cells[x, z].z = z; 
                
                }
            }
    }
    
    // a function for calculating how many of a cell's neighbors are alive
    void aliveNeighbors(){
        // the max variable here is used to help see if the index is going to go out of bounds when you try to locate a cell's neighbors
        // this is useful so you don't get errors when you're looking at cells that are on the edges of the board
        int max = boardLength;
        // in this for loop "i" is going to be used for the x position
        for(int i = 0; i < max; i++){
            // and "j" will be used for the z position
            for(int j = 0; j < max; j++){
                // at the start of every inner loop reset the variable for the number of alive neighbors to 0
                int numAlive = 0;
                // if i+1 is less then the max index of the board then you have a viable neighbor to the right
                if(i + 1 < max){ // middle right neighbor
                    // if that neighbor is alive then increment the number of alive neighbors by 1
                    if(cells[i+1, j].alive == true){
                        numAlive++; }}
                // if j+1 is less then the max length of the board then you have another viable neighbor and can increment the count
                if(j + 1 < max){ // bottom middle neighbor
                    if(cells[i, j+1].alive == true){
                       numAlive++; }}
                // with the same logic, if i-1 is greater then 0, the minimum possible index for any cell on the board,
                // then you have a viable neighbor and can increment the count by 1
                if(i - 1 >= 0){ // middle left neighbor
                    if(cells[i-1, j].alive == true){
                        numAlive++; }}
                // this works the same for j
                if(j - 1 >= 0){ // top middle neighbor
                    if(cells[i, j-1].alive == true){
                        numAlive++; }}
                // now when you want to look at the neighbors in the corners you have to use both i and j indices
                // and the logic works the same
                if(i + 1 < max && j + 1 < max){ // bottom right neighbor
                    if(cells[i+1, j+1].alive == true){
                        numAlive++; }}
                if(i + 1 < max && j - 1 >= 0){ // top right neighbor
                    if(cells[i+1, j-1].alive == true){
                        numAlive++; }}
                if(i - 1 >= 0 && j + 1 < max){ // bottom left neighbor
                    if(cells[i-1, j+1].alive == true){
                        numAlive++; }}
                if(i - 1 >= 0 && j - 1 >= 0){ // top left neighbor
                    if(cells[i-1, j-1].alive == true){
                        numAlive++; }}
                // when that's all said and done you can set the cell's variable for storing it's # of alive neighbors to the count that you got after all those conditionals
                cells[i, j].aliveNeighbors = numAlive;
            }    
        }    
    }
    
    // this is a function that implements the rules of the game of life
    void gameRules(){
        // you use nested for loops again to access both indices in the cell array
        for(int a = 0; a < boardLength; a++){
            for(int b = 0; b < boardLength; b++){
                // if the cell at this index is alive you to check if it has between 2 adn 3 neighbors, if so it stays alive
                // otherwise you use a conditional to set it's state to false(dead) if it has more than 3 or less than 2 neighbors
                // this is also when I change the variable for previouslyDead to true, to signify that the cell has died at some point, then I change it's color correspondingly
                if(cells[a, b].alive == true){
                    if(cells[a, b].aliveNeighbors > 3 || cells[a, b].aliveNeighbors < 2){
                        cells[a, b].alive = false;
                        cells[a, b].previouslyDead = true;
                        cells[a, b].changeColor();
                }}    
                // if the cell is dead all you have to check is if it has exactly 3 neighbors
                // if so then the cell becomes alive again and you can change it's color again
                else{
                    if(cells[a, b].aliveNeighbors == 3){
                        cells[a, b].alive = true;
                        cells[a, b].changeColor();
                    }
                }
            }    
        }
        
    }

    // Update is called once per frame
    // in my update function I call the functions for checking for alive neighbors and running the rules of the game every new frame
    // this way the game updates pretty fast and you can see a lot of changes happening to the board.
    void Update()
    {
        aliveNeighbors();
        gameRules();
    }
}
