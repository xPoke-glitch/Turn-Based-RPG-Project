using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : CharacterLoader
{
    void Awake()
    {
        Load();
    }

    public override void Load()
    {
        PlayerData playerData = CharacterDataCollection.Instance.PlayerData;
        if (playerData == null)
            return;
        GameObject playerObject = Instantiate(playerData.BattlePrefab, spawnPosition);
        if (playerObject != null)
        {
            // LoadStats using script inside the GO instantiated
            playerObject.GetComponent<PlayerBattle>().Data = CharacterDataCollection.Instance.PlayerData;
            playerObject.GetComponent<PlayerBattle>().Health = CharacterDataCollection.Instance.PlayerData.CurrentHealth;
        }
    }
}
