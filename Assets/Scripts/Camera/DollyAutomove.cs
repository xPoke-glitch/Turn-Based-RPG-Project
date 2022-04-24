using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DollyAutomove : MonoBehaviour
{
    [SerializeField]
    private float dollyMovementRate; // aka change per second

    private CinemachineTrackedDolly _dolly;
    void Start()
    {
        _dolly = this.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineTrackedDolly>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _dolly.m_PathPosition += dollyMovementRate * Time.deltaTime;
    }
}
