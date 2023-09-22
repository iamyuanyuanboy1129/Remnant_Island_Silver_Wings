using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class SwitchCam : MonoBehaviour
{
    public CinemachineVirtualCamera vC2;
    // Start is called before the first frame update
    void Start()
    {
        vC2 = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToHigherPriority()
    {
        vC2.Priority = 15;
    }
    public void ChangeToLowerPriority()
    {
        vC2.Priority = 5;
    }
}
