using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public GameObject coin;
    // public static CoinScript coinInstance;
    //public GameScript fuelInfo;
    
    // Start is called before the first frame update
    void Start()
    {
        // coinInstance = this;
    }
    
    //private void OnTriggerEnter(Collider thing){
        //if(thing.CompareTag("Plane")){
            
            //fuelInfo.updateFuel(1);
            //Destroy(coinInstance);
        //}
    //}

    // Update is called once per frame
    void Update()
    {
      float rotation = 5 * Time.deltaTime;
      coin.transform.Rotate(0, rotation, 0, Space.Self);
      
      float terrainY = Terrain.activeTerrain.SampleHeight(transform.position);
      if (transform.position.y < terrainY)
      {
        transform.position = new Vector3(Random.Range(-50, 950), Random.Range(10, 75), Random.Range(-50, 950));
      }
      
    }
}
