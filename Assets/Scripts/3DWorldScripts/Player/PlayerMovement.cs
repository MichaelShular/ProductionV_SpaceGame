using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Old Code for testing 
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    [SerializeField] private float speed;
    private Vector3 dir;
    private float movementtype;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = this.GetComponent<Rigidbody>();
        speed = 1;
        movementtype = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            movementtype = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            movementtype = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            movementtype = 2;
        }

        switch (movementtype)
        {
            case 0:
                    dir = new Vector3(Input.GetAxisRaw("Turning"), Input.GetAxisRaw("Depth"),1);
                    //this.transform.Rotate(new Vector3(Input.GetAxisRaw("Vertical") / 2, 0, 0), Space.Self);
                break;
            case 1:
                //playerRigidbody.AddTorque( new Vector3(Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal"), 0 ), ForceMode.Force );
                //transform.RotateAround(Vector3.zero, Vector3.up, Input.GetAxisRaw("Horizontal") * 50 * Time.deltaTime);
                //transform.RotateAround(Vector3.zero, Vector3.right, Input.GetAxisRaw("Vertical") * 50 * Time.deltaTime);
                


                if (this.transform.rotation.eulerAngles.x <= 80 && this.transform.rotation.eulerAngles.x >= -1  || this.transform.rotation.eulerAngles.x <= 361 && this.transform.rotation.eulerAngles.x >= 280)
                    this.transform.Rotate(new Vector3(Input.GetAxisRaw("Vertical")/2, 0, 0), Space.Self);
                Debug.Log(this.transform.rotation.eulerAngles.x);
                
                
                if (this.transform.rotation.eulerAngles.x >= 80 && this.transform.rotation.eulerAngles.x <= 100)
                    transform.rotation = Quaternion.Euler(new Vector3(79, this.transform.rotation.eulerAngles.y, 0));

                if (this.transform.rotation.eulerAngles.x <= 280 && this.transform.rotation.eulerAngles.x >= 200)
                    transform.rotation = Quaternion.Euler(new Vector3(281, this.transform.rotation.eulerAngles.y, 0));

                this.transform.Rotate(new Vector3(0, Input.GetAxisRaw("Horizontal")/2, 0), Space.Self);
                transform.rotation = Quaternion.Euler( new Vector3(this.transform.rotation.eulerAngles.x, this.transform.rotation.eulerAngles.y, 0 ));
                break;
            case 2:
                transform.Rotate(Input.GetAxisRaw("Vertical") * 0.1f , Input.GetAxisRaw("Depth") * 50 * Time.deltaTime, Input.GetAxisRaw("Horizontal") * 50 * Time.deltaTime);
                break;

            default:
                break;

        }
         

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

        
        
        

    }
    void FixedUpdate()
    {
        if (playerRigidbody.velocity.magnitude <= 20)
        {
            switch (movementtype)
            {
                case 0:
                    
                    playerRigidbody.angularVelocity  =  new Vector3(0, Input.GetAxisRaw("Horizontal"),0);
                    //float a = Vector3.Angle(dir, playerRigidbody.angularVelocity);
                    dir = Quaternion.AngleAxis(transform.rotation.eulerAngles.y, Vector3.up) * dir;
                    //dir += Quaternion.AngleAxis(transform.rotation.eulerAngles.z, Vector3.forward) * dir;
                    playerRigidbody.AddForce( dir * 0 , ForceMode.VelocityChange);
                    break;
                case 1:
                    playerRigidbody.AddForce(transform.forward * 0.5f / 2, ForceMode.VelocityChange);
                    break;
                case 2:
                    playerRigidbody.AddForce(transform.forward * 0.1f / 2, ForceMode.VelocityChange);
                    break;
                default:
                    break;

            }
            //acceleration += Input.GetAxisRaw("Turning");
            //float a = Vector3.Angle(new Vector3( 0, , 0), dir);

           

            //Debug.Log(acceleration);
            
            //Vector3 turn = 
          
        }
    }
}
