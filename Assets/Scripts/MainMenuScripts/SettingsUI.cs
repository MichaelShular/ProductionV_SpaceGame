using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spaceShipRotationBoxWidth(float size)
    {
        PlayerPrefs.SetInt("BoxWidth", (int)size);
    }
    public void spaceShipRotationBoxHeight(float size)
    {
        PlayerPrefs.SetInt("BoxHeight", (int)size);
    }

    public void gameVolume(float size)
    {
        AudioListener.volume = size;
    }
}
