using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText;
    public TMP_Text highscoreText;

    public GameObject roadPrefab;
    public GameObject catPrefab;
    public GameObject groundPrefab;
    public CharacterController cc;
    public GameObject cameraObject;
    public GameObject br1;
    public GameObject br2;
    public GameObject br3;
    public List<GameObject> betweenRoadThings = new List<GameObject>();
    public List<GameObject> kitties = new List<GameObject>();
    public bool endGame = false;

    //int currentHighScore = PlayerPrefs.GetInt("highscore");

    public static GameManagerScript SharedInstance;
    private void Awake()
    {
        SharedInstance = this;
        // GameObject cat = Instantiate(catPrefab, new Vector3(0, 0, -190), Quaternion.identity);
        PlayerPrefs.SetInt("highscore", 0);
        
        //DontDestroyOnLoad(currentHighScore);
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
        generateNewSection();

        score = kitties.Count;
        scoreText.text = score.ToString();
        int currentHighScore = PlayerPrefs.GetInt("highscore");
        if (score > currentHighScore)
        {
            PlayerPrefs.SetInt("highscore", score);
            highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("highscore").ToString();
        }
        

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
        if (cc.transform.position.x < -99)
        {
            cc.transform.position = new Vector3(-99, cc.transform.position.y, cc.transform.position.z);
        }
        else if (cc.transform.position.x > 99)
        {
            cc.transform.position = new Vector3(99, cc.transform.position.y, cc.transform.position.z);
        }
        else if (cc.transform.position.z < -199)
        {
            cc.transform.position = new Vector3(cc.transform.position.x, cc.transform.position.y, -199);
        }
       

        cameraObject.transform.position = catPrefab.transform.position + (-catPrefab.transform.forward * 17) + (Vector3.up * 12);
        cameraObject.transform.LookAt(catPrefab.transform);


        if (endGame == true)
        {
            SceneManager.LoadScene("EndScreen");
        }
    }

    void instantiateRoadsEtc(float currentPos)
    {
        for (int i = -18; i < 20; i += 1)
        {
          
            Vector3 pos = new Vector3(0, 0, currentPos + (i * 10));
            if (i % 2 == 0)
            {

                Instantiate(roadPrefab, pos, Quaternion.identity);
            }
            else
            {
                GameObject betweenRoad = betweenRoadThings[Random.Range(0, 3)];
                Instantiate(betweenRoad, pos, Quaternion.identity);
            }
        }
    }

    void generateNewSection()
    {
        if (cc.transform.position.z % 170 == 0)
        {
            Vector3 newPos = new Vector3(0, 0, cc.transform.position.z + 230);
            GameObject newGround = Instantiate(groundPrefab, newPos, Quaternion.identity);
            instantiateRoadsEtc(cc.transform.position.z);
        }
    }
}



// if the player's position is a certain mod then call generateSection function
//thjis function will instantiate a new ground, new roads, and new inbetween things for this new section