using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //public event Action walk;
    
    public static GameManager SharedInstance;
    
    public List<ObjectScript> objectPool = new List<ObjectScript>();
    ObjectScript selectedObject;
    
    public GameObject character;
    
    public GameObject roadPrefab;
    public GameObject housePrefab;
    public GameObject aptPrefab;
    public GameObject bakeryPrefab;
    public GameObject gazeboPrefab;
    public GameObject treePrefab;
    public GameObject squirrelPrefab;
    public GameObject benchPrefab;
    public GameObject sparklePrefab;
    
    public TMP_Text winText;
    public TMP_Text moneyText;
    int money = 500;
    public bool hasWon = false;
    
    
        
    //public ObjectScript SelectObj(ObjectScript obj)
    //{   
        //// Deselect any units that think they are selected
        //foreach (ObjectScript ob in objectPool) {
            //ob.selected = false;
        //}
        //selectedObject = obj;
        //selectedObject.selected = true;

        ////UnitSelectedHappened?.Invoke(unit);
        //return selectedObject;
    //}
    
    
    
    void Awake(){
        SharedInstance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
        //units = new List<UnitScript>();
        
        moneyText.text = money.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(money > 0){
        
            if(Input.GetMouseButtonDown(0)){
            
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                
                if(Physics.Raycast(ray, out hit, 999999, ~LayerMask.NameToLayer("objects"))){
                    //Vector3 closePos = new Vector3 (100000, 0, 100000);
                    float currentMaxDist = 10000f;
                    ObjectScript closestObj = null;
                    foreach(ObjectScript o in objectPool){
                        float dist = Vector3.Distance(o.transform.position, hit.point);
                        if(dist < currentMaxDist){
                            closestObj = o;
                        }
                    }
                    if(Input.GetKey(KeyCode.Q)){
                        closestObj.transform.Rotate(0, 90, 0, Space.Self);
                    }
                    if(Input.GetKey(KeyCode.E)){
                        closestObj.transform.Rotate(0, -90, 0, Space.Self);    
                    }
                    if(Input.GetKey(KeyCode.Delete) || Input.GetKey(KeyCode.Backspace)){
                        Destroy(closestObj.gameObject);
                    }
                    //ObjectScript selectedo = SelectObj(closestObj);
                    //Debug.Log(closestObj);
                }
                
                if(Physics.Raycast(ray, out hit, 999999, ~LayerMask.NameToLayer("Ground"))){
                
                if(selectedObject == null){
                
                    if(Input.GetKey(KeyCode.Alpha1)){
                        // roads are worth 5
                        GameObject newObject = Instantiate(roadPrefab, hit.point, Quaternion.identity);
                        objectPool.Add(newObject.GetComponent<ObjectScript>());
                        money -= 5;
                        moneyText.text = money.ToString();
                    }
                    else if(Input.GetKey(KeyCode.Alpha2)){
                        // houses are worth 20
                        GameObject newObject = Instantiate(housePrefab, hit.point, Quaternion.identity);
                        objectPool.Add(newObject.GetComponent<ObjectScript>());
                        money -= 20;
                        moneyText.text = money.ToString();
                    }
                    else if(Input.GetKey(KeyCode.Alpha3)){
                        // apartments are worth 25
                        GameObject newObject = Instantiate(aptPrefab, hit.point, Quaternion.identity);
                        objectPool.Add(newObject.GetComponent<ObjectScript>());
                        money -= 25;
                        moneyText.text = money.ToString();
                    }
                    else if(Input.GetKey(KeyCode.Alpha4)){
                        // bakerys are worth 15
                        GameObject newObject = Instantiate(bakeryPrefab, hit.point, Quaternion.identity);
                        objectPool.Add(newObject.GetComponent<ObjectScript>());
                        money -= 15;
                        moneyText.text = money.ToString();
                    }
                    else if(Input.GetKey(KeyCode.Alpha5)){
                        // gazebos are worth 15
                        GameObject newObject = Instantiate(gazeboPrefab, hit.point, Quaternion.identity);
                        objectPool.Add(newObject.GetComponent<ObjectScript>());
                        money -= 15;
                        moneyText.text = money.ToString();
                    }
                    else if(Input.GetKey(KeyCode.Alpha6)){
                        // trees are worth 10
                        GameObject newObject = Instantiate(treePrefab, hit.point, Quaternion.identity); 
                        objectPool.Add(newObject.GetComponent<ObjectScript>());
                        money -= 10;
                        moneyText.text = money.ToString();
                    }
                    else if(Input.GetKey(KeyCode.Alpha7)){
                        // benchs are worth 5
                        GameObject newObject = Instantiate(benchPrefab, hit.point, Quaternion.identity);
                        objectPool.Add(newObject.GetComponent<ObjectScript>());
                        money -= 5;
                        moneyText.text = money.ToString();
                    }
                    else if(Input.GetKey(KeyCode.Alpha8)){
                        // squirrels are worth 5
                        GameObject newObject = Instantiate(squirrelPrefab, hit.point, Quaternion.identity);
                        objectPool.Add(newObject.GetComponent<ObjectScript>());
                        money -= 5;
                        moneyText.text = money.ToString();
                    }
                    
                } 
                }
                
            }
        }
        else{
            hasWon = true;
            winText.text = "Game over!";
            //particleSystem.Emit();
            //particleSystem.Play();
            //GameObject sparkle = Instantiate(sparklePrefab, canvas.transform.position, Quaternion.identity);
            //Destroy(sparkle, 8);
        }
    }
}
