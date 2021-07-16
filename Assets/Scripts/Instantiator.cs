using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class Instantiator : MonoBehaviour
{
    private static TerrainTileMonoBehaviour terrainTilePrefab;
    
    public static TerrainTileMonoBehaviour TerrainTilePrefab {set => terrainTilePrefab = value;}
    public static TerrainTileMonoBehaviour TerrainTile()
    {
        return Instantiate(terrainTilePrefab);
    }
}
