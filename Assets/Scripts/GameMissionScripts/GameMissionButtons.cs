using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMissionButtons : MonoBehaviour
{
    public void GamePlaySceneButton()
    {
        SceneManager.LoadScene("3DWorldScene");
    }

    public void BackToMainMenuButtion()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

}
