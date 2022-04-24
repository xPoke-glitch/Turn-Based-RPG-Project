using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBattleCharacter
{
    // Persistent attributes
    public CharacterData Data { get; set; }
    // Battle Instance attributes
    public int Health { get; set; }
    public int AdditionalDEFFromAction { get; set; }
    // Methods
    public void Damage(int amount);
    public void Defend();
    public void Die();
    public void ResetBuff();
}
