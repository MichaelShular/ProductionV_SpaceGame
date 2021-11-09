using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyBulletPool : MonoBehaviour
{
    [SerializeField] private EnemyBulletFactory bulletFactory;
    private Queue<GameObject> enemyBulletPool;
    [SerializeField] private int amountOfBullets;
    // Start is called before the first frame update
    void Start()
    {
        buildBulletPool();
    }

    private void Update()
    {

    }
    private void buildBulletPool()
    {
        enemyBulletPool = new Queue<GameObject>();

        for (int i = 0; i < amountOfBullets; i++)
        {
            var tempBullet = bulletFactory.createPlayerBullet();
            enemyBulletPool.Enqueue(tempBullet);
        }
    }

    public GameObject getBulletFromPool()
    {
        GameObject tempBullet = null;
        if (enemyBulletPool.Count < 1)
        {
            AddNewBulletToPool();
        }
        tempBullet = enemyBulletPool.Dequeue();
        tempBullet.GetComponent<EnemyBulletLifeTime>().resetEnemyBulletLifeTime();

        tempBullet.SetActive(true);
        return tempBullet;
    }

    public void returnBulletToPool(GameObject bullet)
    {
        enemyBulletPool.Enqueue(bullet);
        bullet.SetActive(false);
    }

    private void AddNewBulletToPool()
    {
        var tempBullet = bulletFactory.createPlayerBullet();
        enemyBulletPool.Enqueue(tempBullet);
    }
}
