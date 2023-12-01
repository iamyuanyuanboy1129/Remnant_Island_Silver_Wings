using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TwoD
{
    public class ChangeSceneAfterDead : MonoBehaviour
    {
        [SerializeField, Header("下一個場景名稱")]
        public string nextSceneName;

        public AudioManager aud;
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
                aud.StopBG();
                StartCoroutine(WaitToChangeScene());
            }
        }
        IEnumerator WaitToChangeScene()
        {
            yield return new WaitForSeconds(3);
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneName);
        }
    }
}
