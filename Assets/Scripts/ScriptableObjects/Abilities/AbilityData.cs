using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability Data", fileName = "Ability Data")]
public class AbilityData : ScriptableObject
{
    public string Name;
    public string Description;
    public int DMG;
    public int UnlockLevel;
    public string AnimationName;
}
