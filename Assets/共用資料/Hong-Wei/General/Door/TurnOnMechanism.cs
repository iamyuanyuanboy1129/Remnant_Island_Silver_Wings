﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnMechanism : MonoBehaviour
{
    [SerializeField, Header("要開啟的門")]
    private GameObject door;
    [SerializeField, Header("門移動的總時間"), Range(1f, 5f)]
    private float duration = 3f;
    [SerializeField, Header("門的偏移量"), Range(-5f, 5f)]
    private float offset = 2;

    private bool canTurnOn = false;
    private bool usedagain = false;
    private Vector3 originalPosition;
    private Vector3 targetPosition;
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start()
    {
        originalPosition = door.transform.position;
        targetPosition = originalPosition + Vector3.up * offset;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canTurnOn && !usedagain)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            StartCoroutine(MoveDoor());
            audioManager.PlaySFX(audioManager.mechineStart);
            usedagain = true;
        }
        if (usedagain)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !usedagain)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            canTurnOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !usedagain)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            canTurnOn = false;
        }
    }
}
