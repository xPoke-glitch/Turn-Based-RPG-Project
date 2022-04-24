using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTile : MonoBehaviour
{
    [SerializeField]
    private PlayerData playerData;

    public void Start()
    {
        // Get Prev position
        Vector3 pos = TilesPositionManager.Instance.GetTilePosition(this.gameObject.name);
        if (pos != Vector3.zero)
            this.gameObject.transform.position = pos;
    }
}
