using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCloseMachine : MonoBehaviour
{
    [SerializeField, Header("要關閉的陷阱")] private GameObject trap;
    [SerializeField, Header("提示的物件")] private GameObject hint;

    private bool inMachineRange = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && inMachineRange)
        {
            trap.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hint.SetActive(true);
            inMachineRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hint.SetActive(false);
            inMachineRange = false;
        }
    }
}
