using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollider : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int health;
    [SerializeField] private Slider healthUI;
    [SerializeField] private Image redFilter;
    private Vector4 maxColor;
    private Vector4 minColor;
    [SerializeField] private float colorChangeSpeed;
    float timeElapsed;

    void Start()
    {
        health = 30 + (10 * PlayerPrefs.GetInt("Hull"));
        healthUI.maxValue = health;
        healthUI.value = health;
        maxColor = new Vector4(1.0f, 0.0f, 0.0f, 0.8f);
        minColor = new Vector4(1.0f, 0.0f, 0.0f, 0.0f);

    }

    // Update is called once per frame
    void Update()
    {
        if(redFilter.GetComponent<Image>().color.a != 0)
        {
            
            redFilter.GetComponent<Image>().color = Vector4.Lerp(maxColor, minColor, timeElapsed / colorChangeSpeed);
            timeElapsed += Time.deltaTime;
        }
        else
        {
            timeElapsed = 0;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            ChangePlayerHealth(-10);

            
            redFilter.GetComponent<Image>().color = maxColor;
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
