using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMissionButtons : MonoBehaviour
{
    [SerializeField] private GameObject missionPanel;
    [SerializeField] private GameObject shipPanel;
    private SFXManager sfx;
    private void Start()
    {
        if (GameObject.Find("SFXManager") != null)
        {
            sfx = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        }
    }
    public void GamePlaySceneButton()
    {
        sfx.PlaySFX(SFXID.UIClick);
        SceneManager.LoadScene("3DWorldScene");
    }

    public void BackToMainMenuButtion()
    {
        sfx.PlaySFX(SFXID.UIClick);
        SceneManager.LoadScene("MainMenuScene");
    }

    public void MissionPanel()
    {
        sfx.PlaySFX(SFXID.UIClick);
        if (shipPanel.activeSelf)
        {
            shipPanel.SetActive(!shipPanel.activeSelf);
        }
        missionPanel.SetActive(!missionPanel.activeSelf);
    }

    public void ShipPanel()
    {
        sfx.PlaySFX(SFXID.UIClick);
        if (missionPanel.activeSelf)
        {
            missionPanel.SetActive(!missionPanel.activeSelf);
        }
        shipPanel.SetActive(!shipPanel.activeSelf);
    }

}
