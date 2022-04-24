using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TilesDeleteManager : Singleton<TilesDeleteManager>
{

    public void OnEnable()
    {
        EnemyTile.OnInteract += AddDeleteEntry;
    }

    public void OnDisable()
    {
        EnemyTile.OnInteract -= AddDeleteEntry;

    }

    protected override void Awake()
    {
        base.Awake();

        if(ShareData.DeleteSet == null)
        {
            ShareData.DeleteSet = new HashSet<string>();
        }

        var tiles= FindObjectsOfType<MonoBehaviour>().OfType<IInteractableTile>();
        foreach(IInteractableTile intTile in tiles)
        {
            MonoBehaviour monoTile = intTile as MonoBehaviour;
            if (ShareData.DeleteSet.Contains(monoTile.gameObject.name))
            {
                Destroy(monoTile.gameObject);
            }
        }
    }

    private void AddDeleteEntry(string entry)
    {
        ShareData.DeleteSet.Add(entry);
    }
}
