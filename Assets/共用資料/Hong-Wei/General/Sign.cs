using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    private IInteractable targetItem;

    public bool canPress = false;

    private void Update()
    {
        OnConfirm();
    }

    private void OnConfirm()
    {
        if (canPress && Input.GetKeyDown(KeyCode.F))
        {
            targetItem.TriggerAction();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            canPress = true;
            targetItem = collision.GetComponent<IInteractable>();
            targetItem.Prompt(canPress);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canPress = false;
        targetItem = collision.GetComponent<IInteractable>();
        targetItem.Prompt(canPress);
    }
}
