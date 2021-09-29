using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLifeTime : MonoBehaviour
{
    [SerializeField] float lifeTimeAmount;
    private float timeLeft;
    // Start is called before the first frame update
    void Start()
    {
        lifeTimeAmount = 5;
        timeLeft = lifeTimeAmount + Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft < Time.time)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }

}
