using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyBulletFactory : MonoBehaviour
{
    [SerializeField] GameObject enemyBullet;

    public GameObject createPlayerBullet()
    {
        GameObject tempBullet = null;

        tempBullet = Instantiate(enemyBullet);
        tempBullet.transform.parent = transform;
        tempBullet.SetActive(false);
        return tempBullet;
    }
}
