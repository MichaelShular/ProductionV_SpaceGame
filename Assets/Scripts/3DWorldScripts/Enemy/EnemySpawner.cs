using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int amountOfEnemies;
    
    [SerializeField] private EnemyPool enemyPool;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amountOfEnemies ; i++)
        {
            GameObject tempEnemy = enemyPool.getEnemyFromPool();
            tempEnemy.transform.position = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), Random.Range(-50, 50));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getNumberOfEnemiesInLevel()
    {
        return amountOfEnemies;
    }
}
