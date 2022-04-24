using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterData : ScriptableObject
{
    [Header("General")]
    public string Name;
    public GameObject BattlePrefab;
    [Header("Base Stats")]
    public int MaxHealth;
    public int BasicAttackDMG;
    public int STR;
    public int DEF;
    public int CRT;
    [Header("Learnable Abilities")]
    public AbilityData[] abilities;
}
