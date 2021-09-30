using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private Rigidbody rdbody;
    [SerializeField] private float bulletSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        rdbody = this.GetComponent<Rigidbody>();
        bulletSpeed = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
        rdbody.velocity = this.transform.forward * bulletSpeed; 
    }
}
