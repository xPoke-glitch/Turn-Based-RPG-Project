using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBattle : MonoBehaviour, IBattleCharacter
{
    public int Health { get; set; }
    public int AdditionalDEFFromAction { get; set; }
    public CharacterData Data { get; set; }

    private AnimationHandler _animationHandler;
    private bool _attackOnce = false;
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
        _animationHandler.PlayAnimationByName("die", () => {
        FindObjectOfType<PlayerBattle>().EarnExp(((EnemyData)Data).DropEXP);
        FindObjectOfType<TransitionManager>().PlayTransition("BattleToWorld", () =>{ SceneManager.LoadScene("LevelExample"); });
            Destroy(this.gameObject); 
        });
    }


    public void ResetBuff()
    {
        AdditionalDEFFromAction = 0;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (TurnManager.Instance.State == TurnManager.TurnState.WaitingPlayerInput)
            _attackOnce = false;
        if (TurnManager.Instance.State == TurnManager.TurnState.EnemyTurn && !_attackOnce)
        {
            ResetBuff();
            _attackOnce = true;
            StartCoroutine(WaitBeforeExecutingAction(1.5f));
        }
    }

    private IEnumerator WaitBeforeExecutingAction(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Choose Random Ability
        AbilityData randomAbility = new AbilityData();
        int randomPick = Random.Range(0, Data.abilities.Length + 2);
        if (randomPick == Data.abilities.Length)
        {
            randomAbility.Name = "attack";
        }
        else if (randomPick == Data.abilities.Length + 1)
        {
            randomAbility.Name = "defend";
        }
        else
        {
            randomAbility.Name = Data.abilities[randomPick].Name;
        }

        Debug.Log("[EnemyBattle WaitBeforeExecutingAction] Random action chosen: " + randomAbility.Name);

        // Action execution
        _animationHandler.PlayActionAnimation(this, randomAbility.Name, () =>
        {
            PlayerBattle target = FindObjectOfType<PlayerBattle>();
            ActionProcessor.Process(this, target, randomAbility.Name);
        });
    }
}
