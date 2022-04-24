using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Enemy Data", fileName = "Enemy")]
public class EnemyData : CharacterData
{
    [Header("Extra Enemy Stats")]
    public int DropEXP;
}
