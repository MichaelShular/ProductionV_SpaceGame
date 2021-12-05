using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    BulletPool bulletPool;
    [SerializeField] Transform leftWing;
    [SerializeField] Transform rightWing;
    [SerializeField] private float slowestReload;
    private float reloadSpeed;
    private float currentTime;
    private bool canFire;
    // Start is called before the first frame update
    void Start()
    {
        reloadSpeed = slowestReload / (PlayerPrefs.GetInt("GunReload") + 1);
        bulletPool = GameObject.Find("BulletManager").GetComponent<BulletPool>();
        currentTime = reloadSpeed + Time.time;
        canFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime < Time.time)
        {
            
            currentTime = reloadSpeed + Time.time;
            canFire = true;
        }

        if (canFire && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {

            GameObject a = bulletPool.getBulletFromPool();
            a.transform.localPosition = rightWing.position;

            a.transform.localRotation = this.transform.rotation;
            a.transform.forward = this.transform.forward;
            //a.transform.localPosition += Vector3.right * 3; 


            GameObject b = bulletPool.getBulletFromPool();
            b.transform.localPosition = leftWing.position;

            b.transform.localRotation = this.transform.rotation;
            b.transform.forward = this.transform.forward;
            //b.transform.localPosition += Vector3.left * 3;
            canFire = false;
        }

    }
}
