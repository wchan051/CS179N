using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private Toggle m_MenuToggle;
	private float m_TimeScaleRef = 1f;
    private float m_VolumeRef = 1f;
    private bool m_Paused;
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;




    void Awake()
    {
        m_MenuToggle = GetComponent <Toggle> ();
	}


    private void MenuOn ()
    {
        m_TimeScaleRef = Time.timeScale;
        Time.timeScale = 0f;

        m_VolumeRef = AudioListener.volume;
        AudioListener.volume = 0f;

        m_Paused = true;
    }


    public void MenuOff ()
    {
        Time.timeScale = m_TimeScaleRef;
        AudioListener.volume = m_VolumeRef;
        m_Paused = false;
    }


    public void OnMenuStatusChange ()
    {
        if (m_MenuToggle.isOn && !m_Paused)
        {
            MenuOn();
        }
        else if (!m_MenuToggle.isOn && m_Paused)
        {
            MenuOff();
        }
    }



	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
		    if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

		}
	}

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Loading Menu..");

    }

    public void QuitGame()
    {
        Debug.Log("Quitting game..");
        Application.Quit();

    }

}
