using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class PauseMenuButtons : MonoBehaviour
{
    [SerializeField] Canvas pauseMenuToggle;
    [SerializeField] private TextMeshProUGUI currentMission;
    [SerializeField] private Image redFilter;
    private SFXManager sfx;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("SFXManager") != null)
        {
            sfx = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && Time.timeScale != 0)
        {
            sfx.PlaySFX(SFXID.UIClick);
            redFilter.color = new Vector4(1.0f, 0.0f, 0.0f, 0.0f);
            currentMission.text = "Mission: " + GetComponent<GameState>().getEneimesDefeated().ToString() + " / " + GetComponent<GameState>().getMissionAmount().ToString();
            Time.timeScale = 0;
            pauseMenuToggle.enabled = true;
        }
    }

    public void unpauseGameButton()
    {
        sfx.PlaySFX(SFXID.UIClick);
        Time.timeScale = 1;
        pauseMenuToggle.enabled = false;
    }

    public void quitMissionButton()
    {
        sfx.PlaySFX(SFXID.UIClick);
        Time.timeScale = 1;
        SceneManager.LoadScene("GameMissionScene");
    }


}
