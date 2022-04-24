using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Header("UI")]
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private TextMeshProUGUI nameText;
    [SerializeField]
    private TextMeshProUGUI valueText;

    [Header("Type")]
    [SerializeField]
    private BattleTag battleTag;

    private IBattleCharacter _character;

    private void Start()
    {
        if(battleTag == BattleTag.Player)
        {
            _character = FindObjectOfType<PlayerBattle>();
        }
        else if(battleTag == BattleTag.Enemy)
        {
            _character = FindObjectOfType<EnemyBattle>();
        }
        if(_character != null)
        {
            slider.maxValue = _character.Data.MaxHealth;
            slider.minValue = 0;
            slider.value = _character.Data.MaxHealth;
            nameText.text = _character.Data.Name.ToLower();
            valueText.text = _character.Health + "/" + _character.Data.MaxHealth;
        }
        
    }

    private void Update()
    {
        if (_character != null)
        {
            slider.value = _character.Health;
            valueText.text = _character.Health + "/" + _character.Data.MaxHealth;
        }
    }
}

public enum BattleTag
{
    Player,
    Enemy
}
