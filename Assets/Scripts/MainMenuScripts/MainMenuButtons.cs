using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private Canvas mainMenuCanvas;
    [SerializeField] private Canvas settingsCanvas;
    public void StartButton()
    {
        SceneManager.LoadScene("GameMissionScene");
    }

    public void SettingButton()
    {
        mainMenuCanvas.enabled = !mainMenuCanvas.enabled;
        settingsCanvas.enabled = !settingsCanvas.enabled;
    }

    public void QuitGameButton()
    {
        Application.Quit();
    }

}
