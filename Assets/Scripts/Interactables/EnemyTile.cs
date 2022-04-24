using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyTile : MonoBehaviour, IInteractableTile
{
    [SerializeField]
    private EnemyData enemy;

    public static event Action<string> OnInteract;

    private bool singleCallEvent = false;

    public void Interact()
    {
        if (!singleCallEvent)
        {
            singleCallEvent = true;
            OnInteract(this.gameObject.name);
        }

        PlayerPrefs.DeleteKey("EnemyDataName");
        Debug.Log("'[EnemyTile Interact]: Battle started against "+enemy.Name+" from data: "+enemy.name);
        PlayerPrefs.SetString("EnemyDataName", enemy.name);

        TransitionManager.Instance.PlayTransition("WorldToBattle",()=> { 
            // Change to Battle Scene
            SceneManager.LoadScene("BattleScene");
        });
    }

    void Awake()
    {
        // Get Prev position
        Vector3 pos = TilesPositionManager.Instance.GetTilePosition(this.gameObject.name);
        if(pos!=Vector3.zero)
            this.gameObject.transform.position = pos;
    }

    void Update()
    {
        
    }

}
