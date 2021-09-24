using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    [SerializeField] private float speed;
    private Vector3 dir;
    private float acceleration;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = this.GetComponent<Rigidbody>();
        speed = 1;
    }

    // Update is called once per frame
    private void Update()
    {

         //Forward
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    dir += new Vector3(0, 0, 10);
        //}
        ////Backwards
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    dir += new Vector3(0, 0, -10);
        //}
        ////Strafe Left
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    dir += new Vector3(-5, 0, 0);
        //}
        ////Strafe Right
        //if (Input.GetKeyDown(KeyCode.D))
        //{
        //    dir += new Vector3(5, 0, 0); 
        //}
         
        ////Roll Left
        //if (Input.GetKeyDown(KeyCode.Q))
        //{

        //}
        ////Roll Right
        //if (Input.GetKeyDown(KeyCode.E))
        //{

        //}
        ////Up
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    dir += new Vector3(0, 5, 0);
        //}
        ////Down
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    dir += new Vector3(0, -5, 0);
        //}

        dir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }
    void FixedUpdate()
    {
        if (playerRigidbody.velocity.magnitude <= 20)
        {
            playerRigidbody.AddForce((dir * speed) / 2, ForceMode.VelocityChange);
        }
    }
}
