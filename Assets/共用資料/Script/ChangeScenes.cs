using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// 場景管理器:切換場景&離開場景
/// </summary>
public class ChangeScenes : MonoBehaviour
{
    [SerializeField, Range(0.3f, 3), Header("音效時間")]
    private float soundTime = 1f;

    private string nameSceneToChange;
    /// <summary>
    /// 透過字串切換場景
    /// </summary>
    /// <param name="nameScene"></param>
    public void ChangeScene(string nameScene)
    {
        nameSceneToChange = nameScene;
        Invoke("DelayChangeScene", soundTime);
    }
    private void DelayChangeScene()
    {
        print("開始遊戲");
        UnityEngine.SceneManagement.SceneManager.LoadScene(nameSceneToChange);
        //UnityEngine.SceneManagement.SceneManager.LoadScene("1");
    }
    /// <summary>
    /// 讀取存檔。
    /// </summary>
    public void LoadScene()
    {
        nameSceneToChange = PlayerPrefs.GetString("TargetScene");
        Invoke("DelayChangeScene", soundTime);
    }
    /// <summary>
    /// 退出遊戲
    /// </summary>
    public void Quit()
    {
        Invoke("DelayQuit", soundTime);
    }
    private void DelayQuit()
    {
        print("離開遊戲");
        Application.Quit();
    }
}
