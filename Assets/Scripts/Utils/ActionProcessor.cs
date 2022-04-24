using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ActionProcessor
{
    public static void Process(IBattleCharacter source, IBattleCharacter target, string action)
    {
        // CRT not yet implemented

        if (action.ToLower().Equals("attack"))
        {
            Debug.Log("Attack Done");
            int damage = source.Data.STR + source.Data.BasicAttackDMG - target.Data.DEF - target.AdditionalDEFFromAction;
            Debug.Log(damage);
            target.Damage(damage);
        }
        else if (action.ToLower().Equals("defend"))
        {
            source.AdditionalDEFFromAction = source.Data.DEF - 1;
            source.Defend();
        }
        else
        {
            int damage = 0;
            foreach(AbilityData ability in source.Data.abilities)
            {
                if (ability.Name.ToLower().Equals(action.ToLower()))
                {
                    damage = source.Data.STR + ability.DMG - target.Data.DEF - target.AdditionalDEFFromAction;
                }
            }
            target.Damage(damage);
        }

        TurnManager.Instance.ChangeTurn();
    }
}
