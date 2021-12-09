using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum MissionDifficulty
{
    Rookie,
    Veteran,
    Elite 
}
public class RandomizeMissions : MonoBehaviour
{
    private MissionDifficulty thisMissionDifficulty;
    private int numberOfEnemies;
    private int numberOfToDefeat;
    private int amountOfHealth;
    [SerializeField] TextMeshProUGUI textDifficulty;
    [SerializeField] TextMeshProUGUI textMissionGoal;



    // Start is called before the first frame update
    void Start()
    {
        //for (int i = 0; i < 100; i++)
        //{
        //    thisMissionDifficulty = (MissionDifficulty)Random.Range(0, 3);
        //    Debug.Log(thisMissionDifficulty);
        //}
        thisMissionDifficulty = (MissionDifficulty)Random.Range(0, 3);
        constructMission(thisMissionDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void constructMission(MissionDifficulty mode)
    {
        switch (mode)
        {
            case MissionDifficulty.Rookie:
                numberOfEnemies = Mathf.RoundToInt(Random.Range(10, 40)/10);
                numberOfToDefeat = Mathf.RoundToInt(Random.Range(10, numberOfEnemies * 10)/10);
                amountOfHealth = Random.Range(10, 30);
                textDifficulty.text = "Rookie";
                textMissionGoal.text = "Defeat: " + numberOfToDefeat + " spacecrafts";
                textDifficulty.color = Color.white;
                break;
            case MissionDifficulty.Veteran:
                numberOfEnemies = Mathf.RoundToInt(Random.Range(30, 70) / 10);
                numberOfToDefeat = Mathf.RoundToInt(Random.Range(40, numberOfEnemies * 10) / 10);
                amountOfHealth = Random.Range(30, 50);
                textDifficulty.text = "Veteran";
                textDifficulty.color = Color.blue;
                textMissionGoal.text = "Defeat: " + numberOfToDefeat + " spacecrafts";
                break;
            case MissionDifficulty.Elite:
                numberOfEnemies = Mathf.RoundToInt(Random.Range(60, 110) / 10);
                numberOfToDefeat = Mathf.RoundToInt(Random.Range(50, numberOfEnemies * 10) / 10);
                amountOfHealth = Random.Range(50, 90);
                
                textDifficulty.text = "Elite";
                textDifficulty.color = Color.red;
                textMissionGoal.text = "Defeat: " + numberOfToDefeat + " spacecrafts";
                break;
            default:
                break;
        }
        set3DWorldMissionSettings(numberOfEnemies, numberOfToDefeat, amountOfHealth);
    }

    private void set3DWorldMissionSettings(int amountOfEnemies, int amountToDefeat, int enemyHeath)
    {
        PlayerPrefs.SetInt("AmountOfEnemies", amountOfEnemies);
        PlayerPrefs.SetInt("AmountToDefeat", amountToDefeat);
        PlayerPrefs.SetInt("EnemyHeath", enemyHeath);

    }

}
