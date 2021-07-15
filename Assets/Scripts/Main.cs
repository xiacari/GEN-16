using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private void OnEnable()
    {
        TerrainTile.Prefab = ScriptableObjectInstancesContainer.Instance.Prefabs.TerrainTile;
    }

    private void Start()
    {

        var da = new int[,]
        {
            {2, 2, 2, 2, 0, 0, 0, 0, 0, 0},
            {2, 2, 2, 0, 0, 0, 0, 0, 0, 0},
            {2, 0, 0, 0, 0, 0, 0, 1, 1, 1},
            {0, 0, 0, 0, 1, 1, 1, 1, 0, 0},
            {0, 0, 1, 1, 1, 0, 0, 0, 0, 3},
            {0, 1, 1, 0, 0, 0, 3, 3, 3, 3}
        };
        
        var h = new float[,]
        {
            {2.75f, 3.00f, 2.75f, 2.25f, 1.75f, 1.75f, 1.75f, 1.50f, 1.25f, 1.00f},
            {2.25f, 2.25f, 2.25f, 1.75f, 1.75f, 1.50f, 1.50f, 1.50f, 1.00f, 1.00f},
            {2.25f, 1.75f, 1.75f, 1.50f, 1.50f, 1.50f, 1.25f, 1.00f, 1.00f, 1.00f},
            {1.75f, 1.50f, 1.50f, 1.50f, 1.00f, 1.00f, 1.00f, 1.00f, 0.50f, 0.50f},
            {1.50f, 1.50f, 1.00f, 1.00f, 1.00f, 1.00f, 0.50f, 0.50f, 0.50f, 0.50f},
            {1.25f, 1.00f, 1.00f, 1.00f, 0.50f, 0.50f, 0.25f, 0.25f, 0.25f, 0.25f},
        };

        da = Methods.Flip2DArray(da);
        h = Methods.Flip2DArray(h);

        var tiles = new TerrainTile[da.GetLength(0), da.GetLength(1)];
        for (var i = 0; i < tiles.GetLength(1); i++)
        for (var j = 0; j < tiles.GetLength(0); j++)
            tiles[j, i] = new TerrainTile((j, -i), da[j, i], h[j, i]);
            
        var t = new TileMap(da);
        var g = new Graph(t.ToMovePointsArray());
        Debug.Log(g.DijkstraMap(0, 0));
        Debug.Log(g.DijkstraPath(0, 0, 9, 5));
    }
}
