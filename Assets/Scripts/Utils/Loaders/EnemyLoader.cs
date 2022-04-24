using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoader : CharacterLoader
{
    private void Awake()
    {
        Load();
    }

    public override void Load()
    {
        GameObject enemyObject = null;
        string dataName = PlayerPrefs.GetString("EnemyDataName");
        foreach(ScriptableObject data in CharacterDataCollection.Instance.EnemiesData)
        {
            if (data.name.Equals(dataName))
            {
                EnemyData enemyData = (EnemyData)data;
                enemyObject = Instantiate(enemyData.BattlePrefab, spawnPosition);
                if (enemyObject != null)
                {
                    // LoadStats using script inside the GO instantiated
                    enemyObject.GetComponent<EnemyBattle>().Data = enemyData;
                    enemyObject.GetComponent<EnemyBattle>().Health = enemyData.MaxHealth;
                }
                break;
            }
        }
    }
}
