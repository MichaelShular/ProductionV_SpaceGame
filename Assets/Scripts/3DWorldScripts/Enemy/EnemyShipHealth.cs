using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipHealth : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private EnemyPool enemyPool;
    [SerializeField] private GameObject scrap;

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
            GameObject.Find("EventSystem").GetComponent<GameState>().setEnemiesDefeated();
            GameObject temp = Instantiate(scrap);
            temp.transform.position = transform.position;
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
