using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackGround : MonoBehaviour
{
    private float xAndYRotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("BMGManager") != null)
        {
            GameObject.Find("BMGManager").GetComponent<BMGMananger>().PlayTrack(TrackID.MissionMenu);
        }
    }

    // Update is called once per frame
    void Update()
    {
        xAndYRotation += 1 * Time.deltaTime;       


        this.transform.rotation = Quaternion.Euler(xAndYRotation,xAndYRotation,0);       
    }
}
