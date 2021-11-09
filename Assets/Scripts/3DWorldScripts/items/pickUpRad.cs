using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpRad : MonoBehaviour
{
    private bool isWithinReach;
    private bool notBeingSearched;
    [SerializeField] GameObject drone;
    // Start is called before the first frame update
    void Start()
    {
        isWithinReach = notBeingSearched = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWithinReach && !notBeingSearched)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                GameObject a = Instantiate(drone);
                a.GetComponent<PlayerDroneControl>().setTarget(this.transform);
                a.transform.position = GameObject.Find("DroneSpawn").transform.position;
                notBeingSearched = true;
            }
        }   
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isWithinReach = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isWithinReach = false;
        }
    }
}
