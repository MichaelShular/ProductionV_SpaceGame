using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollider : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int health;
    [SerializeField] private Slider healthUI;
    void Start()
    {
        health = 30 + (10 * PlayerPrefs.GetInt("Hull"));
        healthUI.maxValue = health;
        healthUI.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            ChangePlayerHealth(-10);
        }
    }

    public void ChangePlayerHealth(int healthChange)
    {
        health += healthChange;
        healthUI.value = health; 
    }

    public int getPlayerHealth()
    {
        return health;
    }
}
