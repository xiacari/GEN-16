using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class Instantiator : MonoBehaviour
{
    public static TerrainTileMonoBehaviour TerrainTile(TerrainTileMonoBehaviour go)
    {
        return Instantiate(go);
    }
}
