using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarController : MonoBehaviour
{
    [SerializeField] GameObject icon;
    [SerializeField] private Transform playerTransform;
    private GameObject[] iconInScene;
    private List<Transform> ship;
    // Start is called before the first frame update
    void Start()
    {

       
        ship = new List<Transform>();
        iconInScene = new GameObject[5];
        for (int i = 0; i < iconInScene.Length; i++)
        {
            iconInScene[i] = Instantiate(icon);
            iconInScene[i].transform.parent = transform;
            iconInScene[i].transform.localPosition = new Vector3(0.0f, 0.5f, 0.0f);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < iconInScene.Length; i++)
        {
            iconInScene[i].transform.localPosition = ship[i].position / 200 ;
            //Debug.Log(iconInScene[i].transform.localPosition); 
        }
        //foreach (Transform a in ship)
        //{
        //    tempIcon.transform.localPosition = Vector3.Normalize(a.position) * 0.5f;

        //}
    }

    public void addTransform(GameObject a)
    {
        ship.Add(a.transform);
    }

    public void removeTransform(GameObject a)
    {
        for (int x = 0; 0 < ship.Count; x++)
        {
            if (a.transform.position == ship[x].position)
            {
                ship.RemoveAt(x);
            }
        }
    }
}
