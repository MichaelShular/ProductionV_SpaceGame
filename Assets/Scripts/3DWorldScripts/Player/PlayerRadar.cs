using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRadar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            GameObject.Find("PlayerRadar3D").GetComponent<RadarController>().addTransform(other.gameObject);
            
        } 
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            GameObject.Find("PlayerRadar3D").GetComponent<RadarController>().removeTransform(other.gameObject);

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, 100);
    }
}
