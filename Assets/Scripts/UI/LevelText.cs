using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
{
    [Header("UI")]
    [SerializeField]
    private TextMeshProUGUI text;

    [Header("Target")]
    [SerializeField]
    private PlayerData target;

    private void Start()
    {
        text.text = "lv:"+target.Level.ToString();
    }

    private void Update()
    {
        text.text = "lv:" + target.Level.ToString();
    }
}
