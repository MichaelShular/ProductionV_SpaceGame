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
    [SerializeField] private int costForUpgrade;
    [SerializeField] public string upgradeName;

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

        loadBarBits();

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void upgradeSystem()
    {
        if (hasGotten[hasGotten.Length - 1] || GameObject.Find("EventSystem").GetComponent<ScrapController>().getScrapTotal() < costForUpgrade)
        {
            Debug.Log("Maxed Out or not enough Scrap");
            return;
        }
        for (int i = 0; i < amountOfBarBits; i++)
        {
            if (!hasGotten[i])
            {
                barBits[i].GetComponent<Image>().sprite = greenBarBit;
                hasGotten[i] = true;
                GameObject.Find("EventSystem").GetComponent<ScrapController>().changeScrapTotal(-costForUpgrade);
                PlayerPrefs.SetInt(upgradeName, PlayerPrefs.GetInt(upgradeName) + 1);
                Debug.Log("One Upgrade");
                return;
            }
        }

    }

    public void loadBarBits()
    {
        int temp = PlayerPrefs.GetInt(upgradeName);

        for (int i = 0; i < temp; i++)
        {
            barBits[i].GetComponent<Image>().sprite = greenBarBit;
            hasGotten[i] = true;
        }

    }

}
