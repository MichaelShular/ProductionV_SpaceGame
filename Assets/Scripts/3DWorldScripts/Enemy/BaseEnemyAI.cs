using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyAI : MonoBehaviour
{
    private enum EnemyStates
    {
        MoveToPlayer,
        Shoot

    }
    [SerializeField] private EnemyStates currentState;

    private Rigidbody enemyRigidbody;
    [SerializeField] float speed;
    [SerializeField] float turningSpeed;

    
    private Transform targetTransform;
    [SerializeField] float enemyStoppingDistence;

    [SerializeField] EnemyBulletPool enemyBulletPool;
    [SerializeField]private Transform gunBarrel;

    [SerializeField] private float timeBetweenShot;
    private float timeForNextShot;

    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = this.GetComponent<Rigidbody>();
        targetTransform = GameObject.Find("Player").transform;
        enemyBulletPool = GameObject.Find("EnemyBulletManager").GetComponent<EnemyBulletPool>();
        timeForNextShot = timeBetweenShot;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(targetTransform.position, this.transform.position) < enemyStoppingDistence)
        {
            currentState = EnemyStates.Shoot;
        }
        else
        {
            currentState = EnemyStates.MoveToPlayer;
        }
               

        switch (currentState)
        {
            case EnemyStates.MoveToPlayer:
                turingToPlayer();
                moveToPlayer();
                break;
            case EnemyStates.Shoot:
                turingToPlayer();
                ShootTarget();
                break;
            default:
                break;
        }
    }

    private void moveToPlayer()
    { 
        enemyRigidbody.velocity = this.transform.forward * speed * Time.deltaTime;
    }
    private void turingToPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(targetTransform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turningSpeed * Time.deltaTime );
    }

    private void ShootTarget()
    {
        if(timeForNextShot < Time.time)
        {
            timeForNextShot = timeBetweenShot + Time.time;
            GameObject a = enemyBulletPool.getBulletFromPool();
            a.transform.position = gunBarrel.position;
            a.transform.forward = this.transform.forward;
        }   
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(this.transform.position, transform.forward *5);
    }
}
