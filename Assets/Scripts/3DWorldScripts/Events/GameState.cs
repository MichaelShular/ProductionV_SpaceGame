using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
public class GameState : MonoBehaviour
{
    [SerializeField] private Canvas stateCanvas;
    private PlayerCollider player;
    [SerializeField] private TextMeshProUGUI stateText;
    [SerializeField] private TextMeshProUGUI scrapCollected;
    [SerializeField] private int amountOfEnemiesToDefeat;
    private int amountOfEnemiesDefeated;
    [SerializeField] private Image redFilter;
    private SFXManager sfx;

    // Start is called before the first frame update
    void Start()
    {
        amountOfEnemiesToDefeat = PlayerPrefs.GetInt("AmountToDefeat");
        Debug.Log("Defeat " + amountOfEnemiesToDefeat);
        player = GameObject.Find("Player").GetComponent<PlayerCollider>();
        PlayerPrefs.SetInt("ScrapCollect", 0);
        if (GameObject.Find("BMGManager") != null)
        {
            GameObject.Find("BMGManager").GetComponent<BMGMananger>().PlayTrack(TrackID.BattleMusic);
        }
        if (GameObject.Find("SFXManager") != null)
        {
            sfx = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        }
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
        redFilter.color = new Vector4(1.0f, 0.0f, 0.0f, 0.0f);
        stateCanvas.enabled = true;
        stateText.text = typeOfState;
        scrapCollected.text = "Amount of scrap collected: " + GameObject.Find("Player").GetComponent<PlayerInventory>().getAmountOfScarp().ToString();

        PlayerPrefs.SetInt("ScrapCollect", GameObject.Find("Player").GetComponent<PlayerInventory>().getAmountOfScarp());
        PlayerPrefs.Save();
    }

    public void loadGameMenu()
    {
        sfx.PlaySFX(SFXID.UIClick);
        SceneManager.LoadScene("GameMissionScene");
    }
    
    public void setEnemiesDefeated()
    {
        amountOfEnemiesDefeated++;
    }

    public int getEneimesDefeated()
    {
        return amountOfEnemiesDefeated;
    }

    public int getMissionAmount()
    {
        return amountOfEnemiesToDefeat;
    }
    IEnumerator delayLose()
    {
        yield return new WaitForSeconds(0.5f);
        openGameStateCanvas("Your ship took to much damage");
    }
}
