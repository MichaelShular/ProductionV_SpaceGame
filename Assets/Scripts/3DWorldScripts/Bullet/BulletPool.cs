using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletPool : MonoBehaviour
{
    [SerializeField] private BulletFactory bulletFactory;
    private Queue<GameObject> bulletPool;
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
        bulletPool = new Queue<GameObject>();

        for (int i = 0; i < amountOfBullets; i++)
        {
            var tempBullet = bulletFactory.createPlayerBullet();
            bulletPool.Enqueue(tempBullet);
        }
    }

    public GameObject getBulletFromPool()
    {
        GameObject tempBullet = null;
        if (bulletPool.Count < 1)
        {
            AddNewBulletToPool();
        }
        tempBullet = bulletPool.Dequeue();
        tempBullet.GetComponent<BulletLifeTime>().resetBulletLifeTime();
        
        tempBullet.SetActive(true);
        return tempBullet;
    }

    public void returnBulletToPool(GameObject bullet)
    {
        bulletPool.Enqueue(bullet);
        bullet.SetActive(false);
    }

    private void AddNewBulletToPool()
    {
        var tempBullet = bulletFactory.createPlayerBullet();
        bulletPool.Enqueue(tempBullet);
    }

}
