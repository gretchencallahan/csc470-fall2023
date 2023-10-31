using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameScript : MonoBehaviour
{   
    public static GameScript SharedInstance;
    public TMP_Text fuelText;
    int fuel = 0;
    public GameObject ringPrefab;
    public GameObject coinPrefab;
    public GameObject plane;
    
    // Start is called before the first frame update
    void Start()
    {
        SharedInstance = this;
        int currentFuel = createFuel();
        fuelText.text = "Current fuel level = " + currentFuel.ToString();
        
        for(int n = 0; n < 10; n++){
            float randX = Random.Range(-50, 800);
            float randZ = Random.Range(-50, 800);
            float randY = Random.Range(50, 250);
            Vector3 ringPos = new Vector3(randX, randY, randZ);
            GameObject ring = Instantiate(ringPrefab, ringPos, Quaternion.identity);
            ring.transform.Rotate(0, Random.Range(0, 180), 0, Space.Self);
        }
        
    }


    int createFuel(){
        fuel = 500;
        return fuel;
    }
    public void updateFuel(int amount){
        fuel += amount;
        fuelText.text = "Current fuel level = " + fuel;
        
    }
    
    public bool noFuel(){
        if(fuel < 1){
            fuelText.text = "No more fuel!";
            return true;
        }
        else{
            return false;    
        }
        
    }



    // Update is called once per frame
    void Update()
    {
        int randNum = Random.Range(0, 100);
        if(randNum % 99 == 0){
            updateFuel(-1);
        }
        noFuel();
    }
}
