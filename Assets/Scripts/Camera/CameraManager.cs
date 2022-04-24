using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    [SerializeField]
    private GameObject[] cameras;

    [SerializeField]
    private MenuInput menuInput;

    [SerializeField]
    private float afkTimer;

    private float _currentTimer = 0;

    private void Start()
    {
        _currentTimer = 0;
    }

    private void Update()
    {
        if (menuInput.IsAnyInput)
        {
            // Stop timer
            _currentTimer = 0;
            // Reset Camera
            cameras[0].SetActive(true);
        }
        _currentTimer += Time.deltaTime;
        if(_currentTimer >= afkTimer)
        {
            // Move to AFK Camera
            cameras[0].SetActive(false);
        }
    }
}
