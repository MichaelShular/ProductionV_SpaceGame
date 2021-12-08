using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMissions : MonoBehaviour
{
    [SerializeField] private GameObject mission;
    public int amountOfMissions;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amountOfMissions; i++)
        {
            Instantiate(mission, this.transform);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
