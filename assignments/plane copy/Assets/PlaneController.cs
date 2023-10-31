using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    
    float forwardSpeed = 13f;
    float xRotationSpeed = 20f;
    float yRotationSpeed = 30f;
    float zRotationSpeed = 20f;
    
    public GameObject cameraObject;
    public GameScript gameInfo;
    public GameObject cow;
    public bool beCow = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerEnter(Collider thing){
        if(thing.CompareTag("Plane")){
            Debug.Log("coin!");
            gameInfo.updateFuel(1);
            Destroy(thing);
        }
    }


    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        //float xRotation = vAxis * xRotationSpeed * Time.deltaTime;
        //float yRotation = hAxis * yRotationSpeed * Time.deltaTime;
        //float zRotation = hAxis * zRotationSpeed * Time.deltaTime;
        //transform.Rotate(-xRotation, yRotation, 0.5f*-zRotation, Space.Self);
        
        float xRotation = vAxis * xRotationSpeed * Time.deltaTime;
        float yRotation = hAxis * yRotationSpeed * Time.deltaTime;
        float zRotation = hAxis * zRotationSpeed * Time.deltaTime;

        transform.Rotate(-xRotation, yRotation, 0, Space.Self);



        gameObject.transform.position += gameObject.transform.forward * Time.deltaTime * forwardSpeed;
        
        cameraObject.transform.position = transform.position + -transform.forward * 10 + Vector3.up * 5;
        cameraObject.transform.LookAt(transform);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            forwardSpeed += 20;
        }

        forwardSpeed -= transform.forward.y * 15 * Time.deltaTime;
        forwardSpeed = Mathf.Max(0, forwardSpeed);
        
        
        float terrainY = Terrain.activeTerrain.SampleHeight(transform.position);
        if (transform.position.y < terrainY)
        {
            transform.position = new Vector3(transform.position.x, terrainY, transform.position.z);
            forwardSpeed -= 100 * Time.deltaTime;
        }
        if(gameInfo.noFuel() == true){
            
            beCow = true;
            

        }

    }
}
