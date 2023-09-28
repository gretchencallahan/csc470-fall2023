using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOfLife : MonoBehaviour
{   
    public GameObject cell;
    public CellScript[,] cells;
    public int boardLength = 30;
    
    // Start is called before the first frame update
    void Start()
    {
        generateBoard(boardLength, boardLength);
    }

    void generateBoard(int n, int m){
        
        cells = new CellScript[n, m];
        for(int x = 0; x < n; x++){
            for(int z = 0; z < m; z++){
                
                Vector3 pos = transform.position;
                float boardSpacing = 1f;
                pos.x = pos.x + x * boardSpacing;
                pos.z = pos.z + z * boardSpacing;
                GameObject cellObject = Instantiate(cell, pos, transform.rotation);
                
                cells[x, z] = cellObject.GetComponent<CellScript>();
                cells[x, z].alive = (Random.value < 0.5f);
                cells[x, z].x = x;
                cells[x, z].z = z; }}
        
    }
    
    void aliveNeighbors(){
        int max = boardLength;
        for(int i = 0; i < max; i++){
            for(int j = 0; j < max; j++){
                int numAlive = 0;
                if(i + 1 < max){ // middle right neighbor
                    if(cells[i+1, j].alive == true){
                        numAlive++; }
                }
                if(j + 1 < max){ // bottom middle neighbor
                    if(cells[i, j+1].alive == true){
                       numAlive++; }
                }
                if(i - 1 >= 0){ // middle left neighbor
                    if(cells[i-1, j].alive == true){
                        numAlive++; }     
                }
                if(j - 1 >= 0){ // top middle neighbor
                    if(cells[i, j-1].alive == true){
                        numAlive++; }
                }
                if(i + 1 < max && j + 1 < max){ // bottom right neighbor
                    if(cells[i+1, j+1].alive == true){
                        numAlive++; }
                }
                if(i + 1 < max && j - 1 >= 0){ // top right neighbor
                    if(cells[i+1, j-1].alive == true){
                        numAlive++; }
                }
                if(i - 1 >= 0 && j + 1 < max){ // bottom left neighbor
                    if(cells[i-1, j+1].alive == true){
                        numAlive++; }    
                }
                if(i - 1 >= 0 && j - 1 >= 0){ // top left neighbor
                    if(cells[i-1, j-1].alive == true){
                        numAlive++; }    
                }
                
                cells[i, j].aliveNeighbors = numAlive;
            }    
        }    
    }
    
    void gameRules(){
        for(int a = 0; a < boardLength; a++){
            for(int b = 0; b < boardLength; b++){
                
                if(cells[a, b].alive == true){
                    if(cells[a, b].aliveNeighbors > 3 || cells[a, b].aliveNeighbors < 2){
                        cells[a, b].alive = false;
                        cells[a, b].changeColor();
                    }
                }    
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
    void Update()
    {
        aliveNeighbors();
        gameRules();
    }
}
