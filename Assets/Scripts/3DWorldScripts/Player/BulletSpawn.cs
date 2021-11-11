using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    BulletPool bulletPool;
    [SerializeField] Transform leftWing;
    [SerializeField] Transform rightWing;
    // Start is called before the first frame update
    void Start()
    {
        bulletPool = GameObject.Find("BulletManager").GetComponent<BulletPool>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)  || Input.GetMouseButtonDown(0))
        {
            
            GameObject a = bulletPool.getBulletFromPool();
            a.transform.localPosition = rightWing.position;
            
            a.transform.localRotation = this.transform.rotation;
            a.transform.forward = this.transform.forward;
            //a.transform.localPosition += Vector3.right * 3; 
            

            GameObject b = bulletPool.getBulletFromPool();
            b.transform.localPosition = leftWing.position;
            
            b.transform.localRotation = this.transform.rotation;
            b.transform.forward = this.transform.forward;
            //b.transform.localPosition += Vector3.left * 3;
        }
    }
}
