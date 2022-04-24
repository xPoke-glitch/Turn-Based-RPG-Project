using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterLoader : MonoBehaviour, ILoader
{
    [SerializeField]
    protected Transform spawnPosition;
    /*[SerializeField]
    protected CharacterDataCollection charactersData;*/
    public abstract void Load();
}
