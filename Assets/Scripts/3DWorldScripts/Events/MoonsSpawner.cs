using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject Moon;

    private int numberOfMoonsToSpawn;
    private float moonScale;
    // Start is called before the first frame update
    void Start()
    {
        numberOfMoonsToSpawn = Random.Range(2, 7);
        for (int i = 0; i < numberOfMoonsToSpawn; i++)
        {
            GameObject temp = Instantiate(Moon);
            temp.transform.SetParent(this.transform);
            temp.transform.position = new Vector3(Random.Range(500, 750) * randomSign() , Random.Range(500, 750) * randomSign(), Random.Range(500, 750) * randomSign());

            moonScale = Random.Range(200, 600);
            temp.transform.localScale = Vector3.one * moonScale;
        }
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private float randomSign()
    {
        float sign = Random.value < 0.5f ? -1f : 1f;
        return sign;
    }
}
