using Fungus;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class MechanismManager : MonoBehaviour
{
    public List<int> mechanismsIndex= new List<int>();
    [SerializeField,Header("開門密碼")]
    private List<int> code;
    [SerializeField, Header("要開啟的門")]
    private GameObject door;
    [SerializeField, Header("門移動的總時間"), Range(1f, 5f)]
    private float duration = 3f;
    [SerializeField, Header("門的偏移量"), Range(-5f, 5f)]
    private float offset = 2;

    private Vector3 originalPosition;
    private Vector3 targetPosition;

    private Animator ani0;
    private Animator ani1;
    private Animator ani2;
    private Animator ani3;

    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        ani0 = gameObject.transform.GetChild(0).GetComponent<Animator>();
        ani1 = gameObject.transform.GetChild(1).GetComponent<Animator>();
        ani2 = gameObject.transform.GetChild(2).GetComponent<Animator>();
        ani3 = gameObject.transform.GetChild(3).GetComponent<Animator>();
    }

    private void Start()
    {
        originalPosition = door.transform.position;
        targetPosition = originalPosition + Vector3.up * offset;
    }

    private void Update()
    {
        if (mechanismsIndex.Count == 4)
        {
            if (Enumerable.SequenceEqual(mechanismsIndex, code))
            {
                Debug.Log("<color=red>密碼相符</color>");
                audioManager.PlaySFX(audioManager.correct);
                StartCoroutine(MoveDoor());
                mechanismsIndex.Clear();
            }
            else
            {
                Debug.Log("<color=red>密碼不相符</color>");
                audioManager.PlaySFX(audioManager.mistake);
                ani0.SetTrigger("default");
                ani1.SetTrigger("default");
                ani2.SetTrigger("default");
                ani3.SetTrigger("default");
                mechanismsIndex.Clear();
                BoxCollider2D[] boxColliders= GetComponentsInChildren<BoxCollider2D>();
                foreach(var e in boxColliders)
                {
                    e.enabled = true;
                }
            }
        }
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
}
