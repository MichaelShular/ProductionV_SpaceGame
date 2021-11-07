using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLifeTime : MonoBehaviour
{
    [SerializeField] float lifeTimeAmount;
    private float timeLeft;
    [SerializeField] BulletPool bulletPool;
    // Start is called before the first frame update
    void Start()
    {
        bulletPool = GameObject.Find("BulletManager").GetComponent<BulletPool>();
        lifeTimeAmount = 5;
        timeLeft = lifeTimeAmount + Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft < Time.time)
        {
            bulletPool.returnBulletToPool(this.gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        bulletPool.returnBulletToPool(this.gameObject);
    }

    public void resetBulletLifeTime()
    {
        timeLeft = lifeTimeAmount + Time.time;
    }


}
