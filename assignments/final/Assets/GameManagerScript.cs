using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject roadPrefab;
    public GameObject catPrefab;
    public CharacterController cc;
    public GameObject cameraObject;
    public GameObject br1;
    public GameObject br2;
    public GameObject br3;
    public List<GameObject> betweenRoadThings = new List<GameObject>();
    public bool endGame = false;

    public static GameManagerScript SharedInstance;
    private void Awake()
    {
        SharedInstance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        betweenRoadThings.Add(br1);
        betweenRoadThings.Add(br2);
        betweenRoadThings.Add(br3);

        for (int i = -18; i < 20; i+=1){
            Vector3 pos = new Vector3(0, 0, i * 10);
            if (i % 2 == 0){
                
                Instantiate(roadPrefab, pos, Quaternion.identity);
            }
            else {
                GameObject betweenRoad = betweenRoadThings[Random.Range(0, 3)];
                Instantiate(betweenRoad, pos, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        float forwardspeed = 0;
        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)){
             forwardspeed = 15;
        }
        else{
            forwardspeed = 7;    
        }
        
        Vector3 amountToMove = transform.forward * forwardspeed * vAxis * Time.deltaTime;
        cc.Move(amountToMove);
        Vector3 amountToShift = transform.right * forwardspeed * hAxis * Time.deltaTime;
        cc.Move(amountToShift);
        
        cameraObject.transform.position = catPrefab.transform.position + (-catPrefab.transform.forward * 17) + (Vector3.up * 12);
        cameraObject.transform.LookAt(catPrefab.transform);


        if (endGame == true)
        {
            SceneManager.LoadScene("EndScreen");
        }
    }
}
