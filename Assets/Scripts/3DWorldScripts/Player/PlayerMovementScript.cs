using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] private float speed;
    //[SerializeField] private float turnSpeed;
    [SerializeField] private float changeSpeedAmount;
    [SerializeField] private float sideDashForceAmount;
    private Rigidbody playerRigidbody;
    private float lastClickTime;
    private const float doubleClickAmount = 0.2f; 
    private Vector3 amount = Vector3.zero;
    float maxAmountOfYRotation;
    float maxAmountOfXRotation;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = this.GetComponent<Rigidbody>();
        speed = 0.0f;
        //turnSpeed = 1f;
        changeSpeedAmount = 1f;
        sideDashForceAmount = 45;

        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.mousePosition.y > (Screen.height/2) + 100 )
        {
            //amount += new Vector3(turnSpeed * Time.deltaTime, 0,0);
            maxAmountOfYRotation -= 0.1f * Time.deltaTime;
            maxAmountOfYRotation = Mathf.Clamp(maxAmountOfYRotation, -0.1f, 0.1f);
        }
        else if(Input.mousePosition.y < (Screen.height / 2) - 100)
        {
            //amount -= new Vector3(turnSpeed * Time.deltaTime, 0, 0);
        

            maxAmountOfYRotation += 0.1f * Time.deltaTime;
            maxAmountOfYRotation = Mathf.Clamp(maxAmountOfYRotation, -0.1f, 0.1f);
            //transform.Rotate(Vector3.left * turnSpeed * Time.deltaTime);
        }
        else
        {
            maxAmountOfYRotation = 0;
            //amount = Vector3.zero;

        }

        if (Input.mousePosition.x > (Screen.width / 2) + 100)
        {
            maxAmountOfXRotation += 0.1f * Time.deltaTime;
            maxAmountOfXRotation = Mathf.Clamp(maxAmountOfXRotation, -0.1f, 0.1f);
        }
        else if (Input.mousePosition.x < (Screen.width / 2) - 100)
        {
            maxAmountOfXRotation -= 0.1f * Time.deltaTime;
            maxAmountOfXRotation = Mathf.Clamp(maxAmountOfXRotation, -0.1f, 0.1f);
        }
        else
        {
            maxAmountOfXRotation = 0;
        }

        amount = new Vector3(maxAmountOfYRotation, maxAmountOfXRotation, 0);
        transform.Rotate(amount);
        //transform.Rotate(Input.GetAxisRaw("Mouse Y") * turnSpeed, Input.GetAxisRaw("Mouse X") * turnSpeed, Input.GetAxisRaw("Depth") * turnSpeed);
        
        speed += Input.GetAxisRaw("Mouse ScrollWheel") * changeSpeedAmount;
        if (speed < 0)
        {
            speed = 0;
        }
        if (speed > 0.4f)
        {
            speed = 0.4f;
        }
        
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            float timeSinceLastClick = Time.time - lastClickTime;
            if (timeSinceLastClick <= doubleClickAmount)
            {
                playerRigidbody.AddForce(transform.right * Input.GetAxisRaw("Horizontal") * sideDashForceAmount, ForceMode.Impulse);
            }  
            lastClickTime = Time.time;
            //Debug.Log(new Vector3(timeSinceLastClick, lastClickTime, Time.time));
        }
      
    }

    private void FixedUpdate()
    {
        playerRigidbody.AddForce(transform.forward * speed, ForceMode.VelocityChange);
    }
}
