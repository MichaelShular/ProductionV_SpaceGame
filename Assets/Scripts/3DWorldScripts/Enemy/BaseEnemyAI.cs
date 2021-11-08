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
    private EnemyStates currentState;

    private Rigidbody enemyRigidbody;
    [SerializeField] float speed;
    [SerializeField] float turningSpeed;

    private Transform targetTransform;
    [SerializeField] float enemyStoppingDistence; 
    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = this.GetComponent<Rigidbody>();
        targetTransform = GameObject.Find("Player").transform;
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
                Debug.Log("Shooting");
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
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(this.transform.position, transform.forward *5);
    }
}
