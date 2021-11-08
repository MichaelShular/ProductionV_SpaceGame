using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipHealth : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private EnemyPool enemyPool;

    // Start is called before the first frame update
    void Start()
    {
        enemyPool = GameObject.Find("EnemySpawner").GetComponent<EnemyPool>();
        health = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            GameObject.Find("EventSystem").GetComponent<ScoreManager>().addScore(100);
            enemyPool.returnEnemyToPool(this.gameObject);
        }
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            health -= 10;
            Debug.Log(health);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }

}
