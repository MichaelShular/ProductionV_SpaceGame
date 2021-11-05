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
            GameObject.Find("EventSystem").GetComponent<RadarUI>().addText(other.gameObject);
            
        } 
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            GameObject.Find("EventSystem").GetComponent<RadarUI>().subtractText(other.gameObject);

        }
    }
}
