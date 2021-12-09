using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnMissions : MonoBehaviour
{
    [SerializeField] private GameObject mission;
    public int amountOfMissions;
    [SerializeField] private GameMissionButtons events;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amountOfMissions; i++)
        {
            GameObject temp = Instantiate(mission, this.transform);
            temp.GetComponent<Button>().onClick.AddListener(events.GamePlaySceneButton);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
