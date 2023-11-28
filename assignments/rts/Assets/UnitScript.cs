using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitScript : MonoBehaviour
{
    public GameObject cameraObject;
    public CharacterController cc;
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 amountToMove = new Vector3(0, 0, 0);
        if(GameManager.SharedInstance.hasWon == false){
            float vAxis = Input.GetAxis("Vertical");
            float hAxis = Input.GetAxis("Horizontal");
            float forwardspeed = 5;
            Vector3 amountToMove = transform.forward * forwardspeed * vAxis * Time.deltaTime;
        
            // rotating the character
            float rotation = hAxis * 30 * Time.deltaTime;

            transform.Rotate(0, rotation, 0, Space.Self);
        
            cc.Move(amountToMove);
            if(amountToMove.magnitude > 0){
                animator.SetBool("isWalking", true);
            }
            else{
                animator.SetBool("isWalking", false);
            }
        
            cameraObject.transform.position = this.transform.position + (-this.transform.forward * 25) + (Vector3.up * 15);
            cameraObject.transform.LookAt(this.transform);
        }
    }
}
