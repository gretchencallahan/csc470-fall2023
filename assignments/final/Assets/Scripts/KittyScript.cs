using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittyScript : MonoBehaviour
{
    public GameObject CatCharacter;
    public CharacterController cc;
    public bool once = true;
    public ParticleSystem sparkles;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cat"))
        {
            this.transform.position = new Vector3(cc.transform.position.x, cc.transform.position.y + 2, cc.transform.position.z);
            GameManagerScript.SharedInstance.kitties.Add(this.gameObject);
            //if (once)
            //{
            //    //var sparkleEmission = sparkles.emission;
            //    var sparkleDuration = sparkles.main.duration;

            //    //sparkles.enabled = true;
            //    sparkles.Play();

            //    once = false;
            //    Invoke(nameof(destroyObj), sparkleDuration);

            //}

        }

    }

    void destroyObj()
    {
        Destroy(gameObject);
    }

}
