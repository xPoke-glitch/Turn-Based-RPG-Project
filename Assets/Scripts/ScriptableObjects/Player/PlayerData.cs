using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Data", fileName = "PlayerData")]
public class PlayerData : CharacterData
{
    [Header("Permanent Stats")]
    public int CurrentHealth;
    public int Level;
    public int EXP;
    public int MaxEXP; // or Exp to next level
    
    public int NextLevel(int level)
    {
        return Mathf.RoundToInt(0.04f * Mathf.Pow((float)level, 3) + 0.8f * Mathf.Pow((float)level, 2) + 2 * level);
    }
}
