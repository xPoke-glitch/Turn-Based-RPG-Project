using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    [Header("UI")]
    [SerializeField]
    private Slider slider;

    [Header("Target")]
    [SerializeField]
    private PlayerData target;

    private void Start()
    {
        slider.minValue = 0;
        slider.maxValue = target.MaxEXP;
        slider.value = target.EXP;
    }

    private void Update()
    {
        slider.value = target.EXP;
    }

}
