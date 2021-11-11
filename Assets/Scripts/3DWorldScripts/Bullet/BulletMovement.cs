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
    }

    // Update is called once per frame
    void Update()
    {
        rdbody.velocity = this.transform.forward * bulletSpeed; 
    }

    public void resetVel()
    {
        rdbody.velocity = Vector3.zero;
        rdbody.angularVelocity = Vector3.zero;
    }
}
