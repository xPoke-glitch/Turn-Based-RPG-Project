using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    private Animator _animator;
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _text = GetComponent<TextMeshProUGUI>();
    }

    public void ShowDamage(int amount)
    {
        _text.color = Color.red;
        _text.text = "-" + amount;
        _animator.SetTrigger("ShowDamage");
    }

    public void ShowDefend()
    {
        _text.color = Color.blue;
        _text.text = "Defend";
        _animator.SetTrigger("ShowDamage");
    }
}
