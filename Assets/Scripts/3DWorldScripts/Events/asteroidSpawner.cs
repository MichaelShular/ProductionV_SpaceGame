using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidSpawner : MonoBehaviour
{
    [SerializeField] private float minXpos;
    [SerializeField] private float maxXpos;
    [SerializeField] private float minYpos;
    [SerializeField] private float maxYpos;
    [SerializeField] private float minZpos;
    [SerializeField] private float maxZpos;
    [SerializeField] private float minPulse;
    [SerializeField] private float maxPulse;
    [SerializeField] private float minAmountAsteroids;
    [SerializeField] private float maxAmountAsteroids;
    private float currentAmountAsteroids;
    [SerializeField] private GameObject obj; 


    // Start is called before the first frame update
    void Start()
    {
        currentAmountAsteroids = Random.Range(minAmountAsteroids, maxAmountAsteroids);

        for(int x = 0; x < currentAmountAsteroids; x++)
        {
            GameObject temp = Instantiate(obj);
            temp.transform.parent = transform;
            temp.transform.position = new Vector3(Random.Range(minXpos, maxXpos),
               Random.Range(minYpos, maxYpos), Random.Range(minZpos, maxZpos));
            temp.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(minPulse, maxPulse),
               Random.Range(minPulse, maxPulse), Random.Range(minPulse, maxPulse)), ForceMode.Impulse);
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
