using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private Rigidbody rdbody;
    
    // Start is called before the first frame update
    void Start()
    {
        rdbody = this.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
        rdbody.velocity = this.transform.forward * 5 ; 
    }
}
