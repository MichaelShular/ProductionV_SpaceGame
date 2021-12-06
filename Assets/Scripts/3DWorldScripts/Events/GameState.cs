using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
public class GameState : MonoBehaviour
{
    [SerializeField] private Canvas stateCanvas;
    private PlayerCollider player;
    [SerializeField] private TextMeshProUGUI stateText;
    [SerializeField] private TextMeshProUGUI scrapCollected;
    [SerializeField] private int amountOfEnemiesToDefeat;
    private int amountOfEnemiesDefeated;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerCollider>();
        PlayerPrefs.SetInt("ScrapCollect", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.getPlayerHealth() <= 0)
        {
            StartCoroutine(delayLose());
            
        }

        if( Input.GetKeyDown(KeyCode.L) && amountOfEnemiesDefeated >= amountOfEnemiesToDefeat)
        {
            openGameStateCanvas("Mission Complete");
        }
    }

    private void openGameStateCanvas(string typeOfState)
    {
        Time.timeScale = 0;
        stateCanvas.enabled = true;
        stateText.text = typeOfState;
        scrapCollected.text = "Amount of scrap collected: " + GameObject.Find("Player").GetComponent<PlayerInventory>().getAmountOfScarp().ToString();

        PlayerPrefs.SetInt("ScrapCollect", GameObject.Find("Player").GetComponent<PlayerInventory>().getAmountOfScarp());
        PlayerPrefs.Save();
    }

    public void loadGameMenu()
    {
        SceneManager.LoadScene("GameMissionScene");
    }
    
    public void setEnemiesDefeated()
    {
        amountOfEnemiesDefeated++;
    }

    IEnumerator delayLose()
    {
        yield return new WaitForSeconds(0.5f);
        openGameStateCanvas("Your ship took to much damage");
    }
}
