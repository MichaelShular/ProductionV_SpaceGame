using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float changeSpeedAmount;
    [SerializeField] private float sideDashForceAmount;
    private Rigidbody playerRigidbody;
    private float lastClickTime;
    private const float doubleClickAmount = 0.2f; 

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = this.GetComponent<Rigidbody>();
        speed = 0.1f;
        turnSpeed = 0.1f;
        changeSpeedAmount = 1f;
        sideDashForceAmount = 45;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Input.GetAxisRaw("Vertical") * turnSpeed, Input.GetAxisRaw("Horizontal") * turnSpeed, Input.GetAxisRaw("Depth") * turnSpeed);
        speed += Input.GetAxisRaw("Mouse ScrollWheel") * changeSpeedAmount;
        if (speed < 0)
        {
            speed = 0;
        }
        if (speed > 0.4f)
        {
            speed = 0.4f;
        }
        //Debug.Log(speed);
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
