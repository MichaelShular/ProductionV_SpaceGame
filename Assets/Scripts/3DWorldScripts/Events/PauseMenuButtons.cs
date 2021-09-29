using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuButtons : MonoBehaviour
{
    [SerializeField] Canvas pauseMenuToggle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pauseMenuToggle.enabled = true;
        }
    }

    public void unpauseGameButton()
    {
        Time.timeScale = 1;
        pauseMenuToggle.enabled = false;
    }

    public void quitMissionButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameMissionScene");
    }


}
