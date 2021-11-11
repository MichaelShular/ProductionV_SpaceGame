using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
    [SerializeField] private int amountOfBarBits;
    [SerializeField] private GameObject barBitGrey;
    [SerializeField] private Sprite greenBarBit;
    private GameObject[] barBits;
    private bool[] hasGotten;

    // Start is called before the first frame update
    void Start()
    {
        barBits = new GameObject[amountOfBarBits];
        hasGotten = new bool[amountOfBarBits];

        for (int i = 0; i < amountOfBarBits; i++)
        {
            GameObject temp = barBits[i] = Instantiate(barBitGrey);
            temp.transform.SetParent(this.transform);
            temp.transform.position = this.transform.position;

            hasGotten[i] = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
           
        }
    }

    public void upgradeSystem()
    {
        if (hasGotten[hasGotten.Length -1])
        {
            Debug.Log("Maxed Out");
            return; 
        }
        for (int i = 0; i < amountOfBarBits; i++)
        {
            if (!hasGotten[i])
            {
                barBits[i].GetComponent<Image>().sprite = greenBarBit;
                hasGotten[i] = true;
                Debug.Log("One Upgrade");
                return;
            }
        }

    }


}
