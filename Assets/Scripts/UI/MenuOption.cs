using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuOption : MonoBehaviour
{
    public bool IsPointed { get; private set; }
    public static event Action<string> OnSelect;

    [Header("UI Elements")]
    [SerializeField]
    private GameObject trainglePointer;
    [SerializeField]
    private TextMeshProUGUI optionText;

    [Header("Event")]
    [SerializeField]
    private UnityEvent onSelecet;

    private void Awake()
    {
        trainglePointer.SetActive(false);
        IsPointed = false;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Point()
    {
        if (!IsPointed)
        {
            IsPointed = true;
            trainglePointer.SetActive(true);
        }
    }

    public void RemovePoint()
    {
        if(IsPointed)
        {
            IsPointed = false;
            trainglePointer.SetActive(false);
        }
    }

    public void Select()
    {
        // Check if unity event has something attached
        bool hasTarget = false;
        for (int i = 0; i < onSelecet.GetPersistentEventCount(); i++)
        {
            if (onSelecet.GetPersistentTarget(i) != null)
            {
                hasTarget = true;
                break;
            }
        }
        if (hasTarget)
            onSelecet.Invoke(); // Invoke Unity Event

        Debug.Log("[MenuOption Selcet] Called on "+this.gameObject.name+" - "+ optionText.text + "- Unity Event: "+ hasTarget);
        // Invoke script General Event
        if (OnSelect == null) // There must be at least 1 listener to the event
            return;
        OnSelect(optionText.text);
    }

    public void SetOptionText(string text)
    {
        if (text == null || text.Equals(""))
            return;
        optionText.text = text;
    }

    public string GetOptionText()
    {
        return optionText.text;
    }
}
