using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanismController : MonoBehaviour
{
    [SerializeField, Header("機關編號")]
    private int number;

    private MechanismManager mecha;
    private BoxCollider2D box;

    private Animator ani;

    private bool canTurnOn = false;

    private void Start()
    {
        mecha=GetComponentInParent<MechanismManager>();
        box = GetComponent<BoxCollider2D>();
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canTurnOn)
        {
            mecha.mechanismsIndex.Add(number);
            ani.SetTrigger("Trigger");
            box.enabled = false;
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
