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
        //Get rid of 100 to stop from getting scrap
        scrapTotal = 100 + PlayerPrefs.GetInt("ScrapSaved") + PlayerPrefs.GetInt("ScrapCollect");
        Debug.Log(PlayerPrefs.GetInt("ScrapCollect"));
        PlayerPrefs.SetInt("ScrapCollect", 0);
        PlayerPrefs.SetInt("ScrapSaved", 0);
        loadingScrapAndPowerUp();
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void changeScrapTotal(int a)
    {
        scrapTotal += a;
        scrapAmountUI.text = scrapTotal.ToString();

        PlayerPrefs.SetInt("ScrapSaved", scrapTotal);
        PlayerPrefs.Save();
    }

    public void loadingScrapAndPowerUp()
    {
        scrapAmountUI.text = scrapTotal.ToString();
        PlayerPrefs.SetInt("ScrapSaved", scrapTotal);
        PlayerPrefs.Save();
    }
    public int getScrapTotal()
    {
        return scrapTotal;
    }

    

}
