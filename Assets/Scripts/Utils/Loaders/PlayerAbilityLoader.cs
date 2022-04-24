using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Menu))]
public class PlayerAbilityLoader : MonoBehaviour, ILoader
{
    private Menu _menu;
    private HashSet<string> _addedAbilities;

    public void Load()
    {
        foreach (AbilityData ability in CharacterDataCollection.Instance.PlayerData.abilities)
        {
           if(CharacterDataCollection.Instance.PlayerData.Level >= ability.UnlockLevel && !_addedAbilities.Contains(ability.Name))
           {
                _addedAbilities.Add(ability.Name);
                _menu.AddMenuOption(ability.Name);
            }
        }   
    }

    void Awake()
    {
        _addedAbilities = new HashSet<string>();
        _menu = GetComponent<Menu>();
    }

    private void OnEnable()
    {
        Load();
    }

    void Start()
    {
        Load();
    }

    void Update()
    {
        
    }
}
