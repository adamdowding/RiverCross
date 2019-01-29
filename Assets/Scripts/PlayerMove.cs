using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    GameObject player;
    public float jumpForce;
    public float horizMove;
    public float vertiMove;
    private bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        horizMove = 9.0f;
        vertiMove = 9.0f;
        player = gameObject;
    }
    // Update is called once per frame
    void Update() {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * horizMove;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * vertiMove;
        transform.Translate(x, 0, z);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    public void WaterMovement() {
        jumpForce = 800f;
        horizMove = 3.0f;
        vertiMove = 3.0f;
    }

    public void GroundMovement() {
        jumpForce = 700f;
        horizMove = 9.0f;
        vertiMove = 9.0f;
    }

    private void Jump() {
        if (!isJumping) {
            isJumping = true;
            player.GetComponent<Rigidbody>().AddForce(0, jumpForce, 0);
            Invoke("resetIsJumping", 0.7f);
        }
    }

    private void resetIsJumping(){
        isJumping = false;
    }
}
