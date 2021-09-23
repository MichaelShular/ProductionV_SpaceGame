using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    [SerializeField] private float speed;
    private Vector3 newVel;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = this.GetComponent<Rigidbody>();
        speed = 1000;
    }

    // Update is called once per frame
    private void Update()
    {
         //Forward
        if (Input.GetKeyDown(KeyCode.W))
        {
            newVel += new Vector3(0, 0, 1);
        }
        //Backwards
        if (Input.GetKeyDown(KeyCode.S))
        {
            newVel += new Vector3(0, 0, -1);
        }
        //Strafe Left
        if (Input.GetKeyDown(KeyCode.A))
        {
            newVel += new Vector3(-1, 0, 0);
        }
        //Strafe Right
        if (Input.GetKeyDown(KeyCode.D))
        {
            newVel += new Vector3(1, 0, 0); 
        }
        //Roll Left
        if (Input.GetKeyDown(KeyCode.Q))
        {

        }
        //Roll Right
        if (Input.GetKeyDown(KeyCode.E))
        {

        }
        //Up
        if (Input.GetKeyDown(KeyCode.R))
        {
            newVel += new Vector3(0, 1, 0);
        }
        //Down
        if (Input.GetKeyDown(KeyCode.F))
        {
            newVel += new Vector3(0, -1, 0);
        }
    }
    void FixedUpdate()
    {
       
        playerRigidbody.velocity = newVel * speed * Time.fixedDeltaTime;
    }
}
