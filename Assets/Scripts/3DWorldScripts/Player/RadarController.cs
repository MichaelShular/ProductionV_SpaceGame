using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarController : MonoBehaviour
{
    [SerializeField] GameObject icon;
    [SerializeField] private Transform playerTransform;
    private List<GameObject>  iconInScene;
    private List<Transform> ship;
    // Start is called before the first frame update
    void Start()
    {

       
        ship = new List<Transform>();
        iconInScene = new List<GameObject>();
        //for (int i = 0; i < iconInScene.Length; i++)
        //{
        //    iconInScene[i] = Instantiate(icon);
        //    iconInScene[i].transform.parent = transform;
        //    iconInScene[i].transform.localPosition = new Vector3(0.0f, 0.5f, 0.0f);
        //}
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.forward = Vector3.forward;

        for (int i = 0; i < ship.Count; i++)
        {
            
            iconInScene[i].transform.localPosition = (ship[i].position / 200) - (playerTransform.position/200);
            //Debug.Log(iconInScene[i].transform.localPosition); 
        }
        //Debug.Log(iconInScene.Count);
        //Debug.Log(ship.Count);


        //foreach (Transform a in ship)
        //{
        //    tempIcon.transform.localPosition = Vector3.Normalize(a.position) * 0.5f;

        //}
    }

    public void addTransform(GameObject a)
    {
        ship.Add(a.transform);
        GameObject tempIcon = Instantiate(icon);
        tempIcon.transform.parent = transform;
        tempIcon.transform.localPosition = new Vector3(0.0f, 0.5f, 0.0f);
        iconInScene.Add(tempIcon);
    }

    public void removeTransform(GameObject a)
    {
        for (int x = 0; 0 < ship.Count; x++)
        {
            //Debug.Log(Vector3.Distance(a.transform.position, ship[x].position));
  

            if (Vector3.Distance(a.transform.position, ship[x].position) < 1)
            {
                ship.RemoveAt(x);
                Destroy(iconInScene[x].gameObject);
                iconInScene.RemoveAt(x);
                return;
            }
            
        }
        
    }
}
