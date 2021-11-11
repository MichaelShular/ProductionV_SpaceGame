using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScrapController : MonoBehaviour
{
    [SerializeField] private int scrapTotal;
    [SerializeField] private TextMeshProUGUI scrapAmountUI;
    // Start is called before the first frame update
    void Start()
    {
        scrapTotal = 140;
    }

    // Update is called once per frame
    void Update()
    {
        scrapAmountUI.text = scrapTotal.ToString();
    }

    public void changeScrapTotal(int a)
    {
        scrapTotal += a;
    }

    public int getScrapTotal()
    {
        return scrapTotal;
    }

}
