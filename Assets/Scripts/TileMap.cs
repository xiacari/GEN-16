using System;
using System.Collections.Generic;
using System.Linq;

public class TileMap
{
    private Tile[,] _tiles;

    public TileMap(int[,] tiles)
    {
        _tiles = new Tile[tiles.GetLength(0), tiles.GetLength(1)];
        for (var i = 0; i < tiles.GetLength(1); i++)
        for (var j = 0; j < tiles.GetLength(0); j++)
            _tiles[j, i] = new Tile(tiles[j, i]);
    }

    public float[,] ToMovePointsArray(List<int> terrainBonus = null)
    {
        var result = new float[_tiles.GetLength(0), _tiles.GetLength(1)];
        for (var i = 0; i < _tiles.GetLength(1); i++)
        for (var j = 0; j < _tiles.GetLength(0); j++)
            result[j, i] = terrainBonus == null ? _tiles[j, i].MovePointsCost : terrainBonus.Contains(_tiles[j, i].TerrainType) ? 100 : _tiles[j, i].MovePointsCost;
        return result;
    }
}

internal class Tile
{
    private int _terrainType;
    private float _movePointsCost;
    public int TerrainType => _terrainType;
    public float MovePointsCost => _movePointsCost;

    internal Tile(int terrainType)
    {
        _terrainType = terrainType;
        _movePointsCost = terrainType switch
        {
            0 => 100f,
            1 => 125f,
            2 => 150f,
            3 => 175f,
            _ => float.PositiveInfinity
        };
    }
}
