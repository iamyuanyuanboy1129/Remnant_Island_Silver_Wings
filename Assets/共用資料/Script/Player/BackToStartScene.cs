using System.Collections;
using System.Collections.Generic;
using TwoD;
using UnityEngine;

public class BackToStartScene : MonoBehaviour
{
    private GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        gameObject = GameObject.Find(this.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<HealthSystem>().currentHealth == 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("開始畫面");
        }
    }
}
