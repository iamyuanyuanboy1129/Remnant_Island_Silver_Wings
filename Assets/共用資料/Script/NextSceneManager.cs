using UnityEngine;

public class NextSceneManager : MonoBehaviour
{
    public string nextScene;
    public void SetNextScene()
    {
        PlayerPrefs.SetString("TargetScene", nextScene);
    }
}
