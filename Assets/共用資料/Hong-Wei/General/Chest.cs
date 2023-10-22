using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    private Animator ani;
    private AudioManager audioManager;
    private SpriteRenderer spriteRenderer;

    private bool isDone;

    private void Awake()
    {
        ani = GetComponent<Animator>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        spriteRenderer = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    public void TriggerAction()
    {
        Debug.Log("Open Chest!");
        if (!isDone)
        {
            OpenChest();
            spriteRenderer.enabled = false;
        }
    }

    public void Prompt(bool canPress)
    {
        spriteRenderer.enabled = canPress;
    }

    private void OpenChest()
    {
        ani.SetTrigger("開啟");
        audioManager.PlaySFX(audioManager.openChest);
        isDone = true;
        this.gameObject.tag = "Untagged";
    }
}
