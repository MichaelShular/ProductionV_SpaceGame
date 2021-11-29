using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    private int amountOfScrap;
    [SerializeField] private int inventorySize;
    [SerializeField] private Slider scrapAmountUI;

    // Start is called before the first frame update
    void Start()
    {
        amountOfScrap = 0;
        scrapAmountUI.maxValue = inventorySize;
        scrapAmountUI.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setAmountOfScrap(int amount)
    {
        if(amountOfScrap < inventorySize)
        {
            amountOfScrap += amount;
            scrapAmountUI.value = amountOfScrap;
        }   
    }

    public int getAmountOfScarp()
    {
        return amountOfScrap;
    }
}
