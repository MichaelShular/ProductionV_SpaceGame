using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private float currentScore;
    [SerializeField] private Text displayedScore; 

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addScore(float a)
    {
        currentScore += a;
        Debug.Log(a);
        displayedScore.text = currentScore.ToString();

    }


}
