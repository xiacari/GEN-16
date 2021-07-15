using UnityEngine;

public class TerrainTile
{
    private static TerrainTileMonoBehaviour prefab;
    private TerrainTileMonoBehaviour _mono;
    private (int x, int y) _position;
    private int _type;
    private float _height;
    
    public static TerrainTileMonoBehaviour Prefab
    {
        set => prefab = value;
    }

    public TerrainTile((int, int) position, int type, float height)
    {
        _position = position;
        _type = type;
        _height = height;
        _mono = Instantiator.TerrainTile(prefab);
        _mono.Construct(_position, _type, _height);
    }
}
