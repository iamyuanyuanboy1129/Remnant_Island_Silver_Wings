using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanismController : MonoBehaviour
{
    [SerializeField, Header("機關編號")]
    private int number;

    private MechanismManager mecha;

    private bool canTurnOn = false;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canTurnOn)
        {
            for (int i = 0; i < 4; i++)
            {
                if (mecha.mechanismsIndex[i] == null)
                    mecha.mechanismsIndex[i] = number;
                break;

            }
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
