using UnityEngine;

[CreateAssetMenu(fileName = "_Prefabs", menuName = "ScriptableObjects/PrefabsScriptableObject", order = 1)]
public class PrefabsScriptableObject : ScriptableObject
{
    [SerializeField] private TerrainTileMonoBehaviour terrainTile;
    public TerrainTileMonoBehaviour TerrainTile => terrainTile;
}
