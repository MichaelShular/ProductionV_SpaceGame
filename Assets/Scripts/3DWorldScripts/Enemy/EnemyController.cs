using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private int shipID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getShipID()
    {
        return shipID;
    }

    public void setShipID(int a)
    {
        shipID = a;
    } 
}
