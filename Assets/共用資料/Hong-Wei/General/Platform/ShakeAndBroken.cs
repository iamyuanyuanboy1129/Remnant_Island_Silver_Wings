using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeAndBroken : MonoBehaviour
{
    [SerializeField, Header("搖晃幅度")] private float shakeAmount = 0.03f;
    [SerializeField, Header("搖晃時間")] private float shakeDuration = 3.0f;

    private float shakeTimer = 0;
    private bool isShaked = false;

    private Animator ani;
    private SpriteRenderer spr;
    private BoxCollider2D box;

    private void Start()
    {
        ani = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (isShaked)
        {
            ShakePlatform();
        }
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("Over"))
        {
            StartCoroutine(RecoverPlatform());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isShaked = true;
    }

    private void ShakePlatform()
    {
        if (shakeTimer <= shakeDuration)
        {
            Vector3 offset = Random.insideUnitCircle * shakeAmount;
            transform.position += offset;
            shakeTimer += Time.deltaTime;
        }
        else
        {
            shakeTimer = 0;
            ani.SetTrigger("Breaking");
            isShaked = false;
        }
    }

    private IEnumerator RecoverPlatform()
    {
        spr.enabled = false;
        box.enabled = false;
        yield return new WaitForSeconds(5f);
        spr.enabled = true;
        box.enabled = true;
    }
}