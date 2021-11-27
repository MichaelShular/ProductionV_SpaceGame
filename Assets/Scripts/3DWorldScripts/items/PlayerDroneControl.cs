using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDroneControl : MonoBehaviour
{
    private Rigidbody droneRigidbody;
    [SerializeField] float speed;
    [SerializeField] float turningSpeed;
    private Transform targetTransform;
    private bool isReturning;
    private GameObject pickUpToDestroy;

    // Start is called before the first frame update
    void Start()
    {
        isReturning = false;
        droneRigidbody = this.GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        turingToTarget();
        moveToTarget();
        
    }

    private void moveToTarget()
    {
        droneRigidbody.velocity = this.transform.forward * speed * Time.deltaTime;
    }
    private void turingToTarget()
    {
        Quaternion rotation = Quaternion.LookRotation(targetTransform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turningSpeed * Time.deltaTime);
    }
    public void setTarget(Transform a)
    {
        targetTransform = a;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PickUp" && !isReturning)
        {
            pickUpToDestroy = other.gameObject;
            StartCoroutine(circleItem());
        }

        if(other.tag == "DroneSpawn" && isReturning)
        {
            //call inventory
            GameObject.Find("Player").GetComponent<PlayerInventory>().setAmountOfScrap(10);
            Destroy(this.gameObject); 
        }
    }
    IEnumerator circleItem() 
    {
        yield return new WaitForSeconds(6);
        targetTransform = GameObject.Find("DroneSpawn").transform;
        isReturning = true;
        Destroy(pickUpToDestroy);
    }
        
}
