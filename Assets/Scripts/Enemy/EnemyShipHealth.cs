using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipHealth : MonoBehaviour
{
    [SerializeField] private float health;
   
    // Start is called before the first frame update
    void Start()
    {
        health = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            GameObject.Find("EventSystem").GetComponent<ScoreManager>().addScore(100);
            Destroy(this.gameObject);
        }
      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == 7)
        {
            health -= 10;
            Debug.Log(health);
        }
    }

}
