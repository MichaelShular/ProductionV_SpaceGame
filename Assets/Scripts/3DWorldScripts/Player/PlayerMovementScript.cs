using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
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
    [SerializeField] TextMeshProUGUI speedUI;
    private float speedForUI;
    private float maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = this.GetComponent<Rigidbody>();
        speed = 0.0f;
        //turnSpeed = 1f;
        changeSpeedAmount = 1f;
        sideDashForceAmount = 45;
        maxSpeed = 0.1f + 0.05f * PlayerPrefs.GetInt("Speed");
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
            maxAmountOfYRotation *= 0.99f;
            //amount = Vector3.zero;

        }

        if (Input.mousePosition.x > (Screen.width / 2) + 100)
        {
            maxAmountOfXRotation += 0.1f * Time.deltaTime;
            maxAmountOfXRotation = Mathf.Clamp(maxAmountOfXRotation, -0.5f, 0.5f);
        }
        else if (Input.mousePosition.x < (Screen.width / 2) - 100)
        {
            maxAmountOfXRotation -= 0.1f * Time.deltaTime;
            maxAmountOfXRotation = Mathf.Clamp(maxAmountOfXRotation, -0.5f, 0.5f);
        }
        else
        {
            maxAmountOfXRotation *= 0.99f;
        }

        amount = new Vector3(maxAmountOfYRotation, maxAmountOfXRotation, 0);
        transform.Rotate(amount);
        //transform.Rotate(Input.GetAxisRaw("Mouse Y") * turnSpeed, Input.GetAxisRaw("Mouse X") * turnSpeed, Input.GetAxisRaw("Depth") * turnSpeed);
        
        speed += Input.GetAxisRaw("Mouse ScrollWheel") * changeSpeedAmount;
        if (speed < 0)
        {
            speed = 0;
        }
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
            Debug.Log("max");
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

        speedForUI = Vector3.Magnitude(playerRigidbody.velocity);
        speedUI.text = Mathf.RoundToInt(speedForUI).ToString();
    }

    private void FixedUpdate()
    {
        playerRigidbody.AddForce(transform.forward * speed, ForceMode.VelocityChange);
    }
}
