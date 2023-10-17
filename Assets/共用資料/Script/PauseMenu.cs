using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject keyManager;

    private KeyBoardManager keyBoardManager;

    private void Start()
    {
        keyBoardManager = keyManager.GetComponent<KeyBoardManager>();
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        keyBoardManager.isOpenPauseMenu = false;
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Application.Quit();
    }
}
