using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMissionButtons : MonoBehaviour
{
    [SerializeField] private GameObject missionPanel;
    [SerializeField] private GameObject shipPanel;
    public void GamePlaySceneButton()
    {
        SceneManager.LoadScene("3DWorldScene");
    }

    public void BackToMainMenuButtion()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void MissionPanel()
    {
        if (shipPanel.activeSelf)
        {
            shipPanel.SetActive(!shipPanel.activeSelf);
        }
        missionPanel.SetActive(!missionPanel.activeSelf);
    }

    public void ShipPanel()
    {
        if (missionPanel.activeSelf)
        {
            missionPanel.SetActive(!missionPanel.activeSelf);
        }
        shipPanel.SetActive(!shipPanel.activeSelf);
    }

}
