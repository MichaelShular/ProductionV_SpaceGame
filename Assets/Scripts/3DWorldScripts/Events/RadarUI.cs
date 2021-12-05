using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//not used
public class RadarUI : MonoBehaviour
{
    [SerializeField] private Text disText;
    [SerializeField] private GameObject player;
    private List<Transform> ship;
    private int counter = 0; 
    // Start is called before the first frame update
    void Start()
    {
        ship = new List<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(ship.Count);
        disText.text = "";
        int count = 1;
        foreach (Transform a in ship)
        {   
            float temp = Vector3.Distance(a.transform.position, player.transform.position);
            disText.text += "Enemy " + count + " " + Mathf.RoundToInt(temp).ToString() + "\n";
            count++;
        }
    }

    public void addText(GameObject a)
    {
        ship.Add(a.transform);
        counter++;
        
    }

    public void subtractText(GameObject a)
    {
        for (int x = 0; 0 < ship.Count; x++)
        {
            if(a.transform.position == ship[x].position)
            {
                ship.RemoveAt(x);
            }
        }
        counter--;
    }
}
