using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterforce : MonoBehaviour {


    public GameObject player;
    public Rigidbody playerRb;
    public Rigidbody rb;
    public GameObject ground;
    public GameObject grass;

    public float thrust;

    PlayerMove playerMoveScript;


    // Use this for initialization
    public void Start () {
        rb = GetComponent<Rigidbody>();
        ground = GameObject.Find("Ground");
        grass = GameObject.Find("grass2");
        playerRb = player.GetComponent<Rigidbody>();
        playerMoveScript = player.GetComponent<PlayerMove>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Ground"){
            Physics.IgnoreCollision(ground.GetComponent<MeshCollider>(), gameObject.GetComponent<Collider>());
        }

        else if (col.gameObject.name == "grass2") {
            Physics.IgnoreCollision(grass.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        }
        else if (col.gameObject.name == "Player")
        {
            Debug.Log("You're in the water!");
            playerMoveScript.WaterMovement();
        }
        else{
            Debug.Log("Object Incoming!");
        }
    }

    private void OnTriggerStay(Collider col)
    {
        col.gameObject.GetComponent<Rigidbody>().AddForce(0, 0, thrust);
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Player") {
            col.gameObject.GetComponent<ConstantForce>().force = new Vector3(0, 0, 0);
            playerMoveScript.GroundMovement();
            Debug.Log("You're out the water!");
        }

    }
}
