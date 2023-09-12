using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateDonuts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for(int n = 0; n < 10; n++){
            generateDonut();
        }
    }
    
    public GameObject donutMen;
    public void generateDonut(){
        Vector3 posi = new Vector3(Random.Range(-2, 4), 0, Random.Range(-2, 4));
        GameObject donutObj = Instantiate(donutMen, posi, Quaternion.identity);
    }
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
