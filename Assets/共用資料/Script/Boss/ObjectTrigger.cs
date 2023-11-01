using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrigger : MonoBehaviour
{
    private BoxCollider2D collider2D;
    // Start is called before the first frame update
    void Start()
    {
        print("物件啟動");
        collider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (collider2D.enabled)
        {
            print("Collider is up!");
        }
    }
}
