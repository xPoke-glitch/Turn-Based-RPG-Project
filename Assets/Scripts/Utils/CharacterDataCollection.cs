using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDataCollection : Singleton<CharacterDataCollection>
{
    public PlayerData PlayerData;
    public ScriptableObject[] EnemiesData;
}
