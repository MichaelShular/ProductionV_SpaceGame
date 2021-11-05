using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyPool : MonoBehaviour
{
    [SerializeField] private EnemyFactory enemyFactory;
    private Queue<GameObject> enemyPool;
    private int amountOfEnemies;
    private int currentIDToUse = 5;


    // Start is called before the first frame update
    void Start()
    {
        amountOfEnemies = this.GetComponent<EnemySpawner>().getNumberOfEnemiesInLevel();
        currentIDToUse = 0;
        buildEnemyPool();
    }

    private void buildEnemyPool()
    {
        enemyPool = new Queue<GameObject>();

        for (int i = 0; i < amountOfEnemies; i++)
        {
            var tempEnemy = enemyFactory.createEnemy(currentIDToUse);
            enemyPool.Enqueue(tempEnemy);
            currentIDToUse++;
        }
    }

    public GameObject getEnemyFromPool()
    {
        var tempEnemy = enemyPool.Dequeue();
        tempEnemy.SetActive(true);
        return tempEnemy;
    }

    public void returnEnemyToPool(GameObject enemy)
    {
        enemy.SetActive(false);
        enemyPool.Enqueue(enemy);
    } 
}
