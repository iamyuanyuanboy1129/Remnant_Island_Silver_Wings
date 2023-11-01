using TMPro;
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

namespace TwoD
{
    /// <summary>
    /// 密碼門機關
    /// </summary>
    public class OpenWithPassword : MonoBehaviour
    {
        [SerializeField, Header("輸入密碼欄位")]
        private TMP_InputField passwordFiel;

        [SerializeField, Header("要開啟的門")]
        private GameObject door;
        [SerializeField, Header("門移動的總時間"), Range(1f, 5f)]
        private float duration = 3f;
        [SerializeField, Header("門的偏移量"), Range(-5f, 5f)]
        private float offset = 2;

        private bool canTurnOn = false;
        private Vector3 originalPosition;
        private Vector3 targetPosition;
        private string password;

        private void Awake()
        {
            GetUIObject();
            GetInputFieldData();
        }

        private void Start()
        {
            originalPosition = door.transform.position;
            targetPosition = originalPosition + Vector3.up * offset;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F) && canTurnOn)
            {
                //passwordFiel.


                if (password == "5555")
                {
                    StartCoroutine(MoveDoor());
                }
                else
                {

                }
            }
        }

        /// <summary>
        /// 取得介面物件
        /// </summary>
        private void GetUIObject()
        {
            passwordFiel = GameObject.Find("輸入密碼欄位").GetComponent<TMP_InputField>();
        }
        /// <summary>
        /// 取得輸入欄位資料
        /// </summary>
        private void GetInputFieldData()
        {
            passwordFiel.onEndEdit.AddListener((input) => password = input);
        }

        private IEnumerator MoveDoor()
        {
            float timer = 0;
            while (timer < duration)
            {
                door.transform.position = Vector3.Lerp(originalPosition, targetPosition, (timer / duration));
                timer += Time.deltaTime;
                yield return null;
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                canTurnOn = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                canTurnOn = false;
            }
        }
    }
}
