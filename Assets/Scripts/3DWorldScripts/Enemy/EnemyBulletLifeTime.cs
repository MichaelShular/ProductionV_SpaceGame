using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletLifeTime : MonoBehaviour
{
    [SerializeField] float lifeTimeAmount;
    private float timeLeft;
    [SerializeField] EnemyBulletPool enemyBulletPool;
    // Start is called before the first frame update
    void Start()
    {
        enemyBulletPool = GameObject.Find("EnemyBulletManager").GetComponent<EnemyBulletPool>();
        timeLeft = lifeTimeAmount + Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft < Time.time)
        {
            enemyBulletPool.returnBulletToPool(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {    
        if(other.tag == "Player")
        {
            enemyBulletPool.returnBulletToPool(this.gameObject);
        }
        
    }

    public void resetEnemyBulletLifeTime()
    {
        timeLeft = lifeTimeAmount + Time.time;
    }
}
