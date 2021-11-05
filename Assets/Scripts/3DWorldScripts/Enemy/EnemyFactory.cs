using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private GameObject enemyDrone;
    public GameObject createEnemy(int iD)
    {
        GameObject tempDrone = null;

        tempDrone = Instantiate(enemyDrone);
        tempDrone.GetComponent<EnemyController>().setShipID(iD);
        tempDrone.transform.parent = transform;
        tempDrone.SetActive(false);
        return tempDrone;
    }
    
}
