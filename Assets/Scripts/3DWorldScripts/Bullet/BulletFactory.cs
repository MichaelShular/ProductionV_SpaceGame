using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] 
public class BulletFactory : MonoBehaviour
{
    [SerializeField] GameObject playerBullet;
    
    public GameObject createPlayerBullet()
    {
        GameObject tempBullet = null;

        tempBullet = Instantiate(playerBullet);
        tempBullet.transform.parent = transform;
        tempBullet.SetActive(false);
        return tempBullet;
    }
}
