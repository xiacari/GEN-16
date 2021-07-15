using System;

public class Methods
{
    public static float[,] Flip2DArray(float[,] array)
    {
        var result = new float[array.GetLength(1), array.GetLength(0)];
        for (var i = 0; i < result.GetLength(1); i++)
        for (var j = 0; j < result.GetLength(0); j++)
            result[j, i] = array[i, j];
        return result;
    }
    
    public static int[,] Flip2DArray(int[,] array)
    {
        var result = new int[array.GetLength(1), array.GetLength(0)];
        for (var i = 0; i < result.GetLength(1); i++)
        for (var j = 0; j < result.GetLength(0); j++)
            result[j, i] = array[i, j];
        return result;
    }
}
