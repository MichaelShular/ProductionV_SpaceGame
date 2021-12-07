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

    private bool shieldsUp;
    int currentShieldCount;
    int maxShieldCount;
    float cooldownTimerForShields;

    [SerializeField] private Slider shieldSilderUI;


    void Start()
    {
        health = 30 + (10 * PlayerPrefs.GetInt("Hull"));
        healthUI.maxValue = health;
        healthUI.value = health;
        maxColor = new Vector4(1.0f, 0.0f, 0.0f, 0.8f);
        minColor = new Vector4(1.0f, 0.0f, 0.0f, 0.0f);

        maxShieldCount = PlayerPrefs.GetInt("Shields"); 
        currentShieldCount = maxShieldCount;
        cooldownTimerForShields = 10 - (PlayerPrefs.GetInt("ShieldsCooldown") * 2);

        shieldSilderUI.maxValue = cooldownTimerForShields;
        shieldSilderUI.value = 0;
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
            if (currentShieldCount > 0)
            {
                currentShieldCount--;
                StartCoroutine(coolDownForShields(cooldownTimerForShields));
            }
            else
            {
                ChangePlayerHealth(-10);
                redFilter.GetComponent<Image>().color = maxColor;
            }

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

    IEnumerator coolDownForShields(float timer)
    {
        float animationTime = 0f;
        shieldSilderUI.value = timer;
        while (animationTime < timer)
        {
            animationTime += Time.deltaTime;
            float lerpValue = animationTime / timer;
            shieldSilderUI.value = Mathf.Lerp(timer, 0.0f, lerpValue);
            yield return null;
        }
        //yield return new WaitForSeconds(timer);
        //Debug.Log("UP");
        currentShieldCount++;
    }
}
