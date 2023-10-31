using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingScript : MonoBehaviour
{
    public GameObject ringPrefab;
    public GameObject coinPrefab;
    public GameObject plane;
    public static RingScript ringInstance;
    
    
    // Start is called before the first frame update
    void Start()
    {
        ringInstance = this;
    }
    

    private void OnTriggerEnter(Collider thing){
        if(thing.CompareTag("Plane")){
            
            Debug.Log("hit");
            Vector3 pos = this.transform.position;
            bool addFuel = true;
            for(int i = 0; i < 10; i++){
                if(addFuel == true){
                    
                    float terrainY = Terrain.activeTerrain.SampleHeight(transform.position);
                    Vector3 coinPos = pos;
                    coinPos.z = pos.z + 5;
                    coinPos.x = pos.x - 2;
                    coinPos.y = terrainY;
                    GameObject coin = Instantiate(coinPrefab, coinPos, Quaternion.identity);
                }
                
                int rand = Random.Range(0, 10);
                if(rand % 2 == 0){
                    addFuel = false;
                }  
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
