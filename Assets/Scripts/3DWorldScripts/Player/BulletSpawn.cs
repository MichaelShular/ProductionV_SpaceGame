using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    [SerializeField] private GameObject spawningobject;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)  || Input.GetMouseButtonDown(0))
        {
            GameObject a = Instantiate(spawningobject, this.transform);


            a.transform.localPosition += Vector3.right * 3;
            GameObject b = Instantiate(spawningobject, this.transform);
            b.transform.localPosition += Vector3.left * 3;
        }
    }
}
