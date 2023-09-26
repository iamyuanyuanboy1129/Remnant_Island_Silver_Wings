using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGodSwordCount : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetToZero()
    {
        PlayerPrefs.SetInt("GodSword", 0);
    }

    public void SetToTwo()
    {
        PlayerPrefs.SetInt("GodSword", 2);
    }
}
