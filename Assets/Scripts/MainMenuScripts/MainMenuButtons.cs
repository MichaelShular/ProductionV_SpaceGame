using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("GameMissionScene");
    }

    public void SettingButton()
    {

    }

    public void QuitGameButton()
    {
        Application.Quit();
    }

}
