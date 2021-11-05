using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarController : MonoBehaviour
{
    [SerializeField] GameObject icon;
    // Start is called before the first frame update
    void Start()
    {
        GameObject tempIcon = Instantiate(icon);
        tempIcon.transform.parent = transform;
        tempIcon.transform.localPosition = new Vector3(0.0f, 0.5f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
