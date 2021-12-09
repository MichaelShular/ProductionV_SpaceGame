using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private Canvas mainMenuCanvas;
    [SerializeField] private Canvas settingsCanvas;
    private SFXManager sfx;
    private void Start()
    {
        if (GameObject.Find("SFXManager") != null)
        {
            sfx = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        }
       
    }
    public void StartButton()
    {
        sfx.PlaySFX(SFXID.UIClick);
        SceneManager.LoadScene("GameMissionScene");
    }

    public void SettingButton()
    {

        sfx.PlaySFX(SFXID.UIClick);
        mainMenuCanvas.enabled = !mainMenuCanvas.enabled;
        settingsCanvas.enabled = !settingsCanvas.enabled;
    }

    public void QuitGameButton()
    {
        sfx.PlaySFX(SFXID.UIClick);
        Application.Quit();
    }


}
