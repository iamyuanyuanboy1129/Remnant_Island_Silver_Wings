using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevivalStatue : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vector3 newPos = gameObject.transform.position + new Vector3(0, 2, 0);
            PlayerPrefs.SetString("PositionSaved", newPos.ToString());
            print(this.transform.position.ToString());
        }
    }
}
