using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattle : MonoBehaviour, IBattleCharacter
{
    public CharacterData Data { get; set; }
    public int AdditionalDEFFromAction { get; set; }
    public int Health { get; set; }

    private AnimationHandler _animationHandler;
    private DamageText _damageText;

    private void Awake()
    {
        _animationHandler = GetComponent<AnimationHandler>();
        _damageText = GetComponentInChildren<DamageText>();
    }

    public void Damage(int amount)
    {
        if (amount <= 0)
            return;
        Health -= amount;
        _damageText.ShowDamage(amount);
        if (Health <= 0)
        {
            Health = 0;
            Die();
            return;
        }
        _animationHandler.PlayAnimationByName("hit");
    }

    public void Defend()
    {
        _damageText.ShowDefend();
    }

    public void Die()
    {
        TurnManager.Instance.BattleEnd();
        _animationHandler.PlayAnimationByName("die", () => { Destroy(this.gameObject); });
    }

    public void ResetBuff()
    {
        AdditionalDEFFromAction = 0;
    }

    public void EarnExp(int amount)
    {
        if (amount <= 0)
            return;
        PlayerData data = (PlayerData) Data;
        if((data.EXP + amount) < data.MaxEXP)
        {
            data.EXP += amount;
        }
        else
        {
            data.EXP += amount;
            data.EXP -= data.MaxEXP;
            LevelUp(data);
        }
    }

    private void LevelUp(PlayerData data)
    {
        data.Level++;
        data.MaxEXP = data.NextLevel(data.Level);
        data.STR++;
        if (data.Level % 2 == 0)
        {
            data.DEF++;
        }
    }

    private void OnEnable()
    {
        MenuOption.OnSelect += ActionSelected;
    }

    private void OnDisable()
    {
        MenuOption.OnSelect -= ActionSelected;
    }

    private void ActionSelected(string actionText)
    {
        if (actionText.ToLower().Equals("items") || actionText.ToLower().Equals("ability"))
            return;
        if (TurnManager.Instance.State == TurnManager.TurnState.WaitingPlayerInput)
        {
            ResetBuff();
            Debug.Log("[PlayerBattle ActionSelected] Execute action: " + actionText);
            TurnManager.Instance.PlayerInputSelected();

            // Execute Animation/VFX
            _animationHandler.PlayActionAnimation(this, actionText.ToLower(), () =>
            {
                // OnAnimationVFXFinishedCallback -> Process Action Damage
                EnemyBattle target = FindObjectOfType<EnemyBattle>();
                ActionProcessor.Process(this, target, actionText);
            });
        }
    }

}
