using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        
    }
    public void SwitchScene1()
    {
        SceneManager.LoadScene(1);
        //SceneManager.LoadScene("遊戲畫面(場景一)");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
