using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private void Start()
    {
        var da = new int[,]
        {
            {0, 1, 2, 2, 2, 2, 2, 2, 2, 2},
            {0, 1, 2, 2, 2, 1, 1, 2, 2, 2},
            {0, 1, 1, 2, 1, 1, 1, 1, 1, 2},
            {0, 0, 1, 1, 0, 3, 3, 3, 1, 2},
            {3, 0, 1, 0, 3, 0, 3, 3, 1, 1},
            {3, 3, 0, 3, 3, 3, 3, 1, 1, 2}
        };

        da = Methods.Flip2DArray(da);

        var t = new TileMap(da);
        
        var g = new Graph(t.ToMovePointsArray());
        
        Debug.Log(g.DijkstraMap(0, 0));
        Debug.Log(g.DijkstraPath(0, 0, 9, 5));
    }
}
