using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadScript : MonoBehaviour
{
    public GameObject car1Prefab;
    public GameObject car2Prefab;
    public GameObject car3Prefab;
    public GameObject car4Prefab;
    public GameObject car5Prefab;
    public GameObject car6Prefab;
    public GameObject kittyPrefab;
    
    public List<GameObject> cars = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        cars.Add(car1Prefab);
        cars.Add(car2Prefab);
        cars.Add(car3Prefab);
        cars.Add(car4Prefab);
        cars.Add(car5Prefab);
        cars.Add(car6Prefab);
        //bool genOneGo = true;
        //int genOneCount = 0;
        //while (genOneGo == true){
        //    if(genOneCount % 5 == 0){
        //        StartCoroutine(generateCar());
        //    }
        //    genOneCount++;
        //    if( genOneCount == 100){
        //        genOneGo = false;    
        //    }
        //}
        StartCoroutine(generateMoreCars());

        Vector3 kittyPos = new Vector3(Random.Range(-95, 95), this.transform.position.y, this.transform.position.z);
        GameObject kitty = Instantiate(kittyPrefab, kittyPos, Quaternion.identity);
        // GameManagerScript.SharedInstance.kitties.Add(kitty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator generateCar(){
        while (true){
            GameObject car = cars[Random.Range(0, 6)];  
            GameObject carObj = Instantiate(car, new Vector3(99, 0, this.transform.position.z), Quaternion.identity);

            while(carObj.transform.position.x > -99){
                
                carObj.transform.position += -carObj.transform.right * Time.deltaTime * 10;    
                yield return null;
    
            }
            Destroy(carObj);
            int seconds = Random.Range(0, 10);
            yield return new WaitForSeconds(seconds);
        }
    }

    IEnumerator generateMoreCars() {

        while (true)
        {
            StartCoroutine(generateCar());
            int seconds = Random.Range(0, 5);
            yield return new WaitForSeconds(seconds);
        }
    }

    
}
