using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesPositionManager : Singleton<TilesPositionManager>
{
    private static Dictionary<string, Vector3> _tilesDictionary = new Dictionary<string, Vector3>();

    private static GameObject gameObjectInstance = null;

    public void OnEnable()
    {
        EnemyTile.OnInteract += UpdatePositions;
    }

    public void OnDisable()
    {
        EnemyTile.OnInteract -= UpdatePositions;
    }

    public Vector3 GetTilePosition(string name)
    {
        Vector3 pos = Vector3.zero;
        _tilesDictionary.TryGetValue(name, out pos);
        return pos;
    }

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);

        if (gameObjectInstance == null)
        {
            gameObjectInstance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }

        Debug.Log(_tilesDictionary.Count);
    }

    private void UpdatePositions(string enemyObjectName)
    {
        EnemyTile[] enemies = FindObjectsOfType<EnemyTile>();
        PlayerTile player = FindObjectOfType<PlayerTile>();

        Vector3 temp = Vector3.zero;

        foreach (EnemyTile tile in enemies)
        {
            if (_tilesDictionary.TryGetValue(tile.gameObject.name, out temp))
                _tilesDictionary.Remove(tile.gameObject.name);
            _tilesDictionary.Add(tile.gameObject.name, tile.transform.position);
        }
        
        if(_tilesDictionary.TryGetValue(player.gameObject.name, out temp))
            _tilesDictionary.Remove(player.gameObject.name);
        _tilesDictionary.Add(player.gameObject.name, player.transform.position);
       
        _tilesDictionary.Remove(enemyObjectName);
    }
}
