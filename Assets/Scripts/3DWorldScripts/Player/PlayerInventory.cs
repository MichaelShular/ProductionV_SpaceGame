using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private int amountOfScrap;

    // Start is called before the first frame update
    void Start()
    {
        amountOfScrap = 0;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setAmountOfScrap(int amount)
    {
        amountOfScrap += amount;
    }

    public int getAmountOfScarp()
    {
        return amountOfScrap;
    }
}
