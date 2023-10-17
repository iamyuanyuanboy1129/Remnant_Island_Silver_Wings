using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardManager : MonoBehaviour
{
    [SerializeField] private GameObject myBag;
    [SerializeField] private GameObject pauseMenu;

    public bool isOpenPauseMenu = false;
    private bool isOpenBag = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isOpenBag)
            {
                myBag.SetActive(false);
                isOpenBag = false;
            }
            else
            {
                myBag.SetActive(true);
                isOpenBag = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isOpenPauseMenu)
            {
                pauseMenu.SetActive(false);
                isOpenPauseMenu = false;
            }
            else
            {
                pauseMenu.SetActive(true);
                isOpenPauseMenu = true;
            }
        }
    }
}
