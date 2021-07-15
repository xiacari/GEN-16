using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;

public class Graph
{
    private Node[,] _nodes;

    public Graph(float[,] distanceArray)
    {
        _nodes = new Node[distanceArray.GetLength(0), distanceArray.GetLength(1)];
        
        
        for (var i = 0; i < _nodes.GetLength(1); i++)
        for (var j = 0; j < _nodes.GetLength(0); j++)
            _nodes[j, i] = new Node();

        for (var i = 0; i < _nodes.GetLength(1); i++)
        for (var j = 0; j < _nodes.GetLength(0); j++)
        {
            if (j > 0)
                _nodes[j, i].AddLine(new Line(distanceArray[j-1, i], _nodes[j-1, i]));
            if (j < _nodes.GetLength(0) - 1)
                _nodes[j, i].AddLine(new Line(distanceArray[j+1, i], _nodes[j+1, i]));
            if (i > 0)
                _nodes[j, i].AddLine(new Line(distanceArray[j, i-1], _nodes[j, i-1]));
            if (i < _nodes.GetLength(1) - 1)
                _nodes[j, i].AddLine(new Line(distanceArray[j, i+1], _nodes[j, i+1]));
            if (j > 0 && i > 0)
                _nodes[j, i].AddLine(new Line(distanceArray[j-1, i-1] * 1.41f, _nodes[j-1, i-1]));
            if (j > 0 && i < _nodes.GetLength(1) - 1)
                _nodes[j, i].AddLine(new Line(distanceArray[j-1, i+1] * 1.41f, _nodes[j-1, i+1]));
            if (j < _nodes.GetLength(0) - 1 && i > 0)
                _nodes[j, i].AddLine(new Line(distanceArray[j+1, i-1] * 1.41f, _nodes[j+1, i-1]));
            if (j < _nodes.GetLength(0) - 1 && i < _nodes.GetLength(1) - 1)
                _nodes[j, i].AddLine(new Line(distanceArray[j+1, i+1] * 1.41f, _nodes[j+1, i+1]));
        }
    }

    private void Dijkstra(int x, int y)
    {
        ResetMarks();
        _nodes[x, y].Mark = 0f;
        for (var i = 0; i < _nodes.Length; i++)
            MinMark().MarkContacts();
    }

    public string DijkstraMap(int x, int y)
    {
        Dijkstra(x, y);
        
        var output = "";

        for (var i = 0; i < _nodes.GetLength(1); i++)
        {
            for (var j = 0; j < _nodes.GetLength(0); j++)
                output += _nodes[j, i].Mark + " ";

            output += '\n';
        }

        return output;
    }
    
    public string DijkstraPath(int x1, int y1, int x2, int y2)
    {
        Dijkstra(x1, y1);
        var output = "";
        var steps = new List<string>();
        var finish = false;
        while (!finish)
        {
            if (_nodes[x2, y2-1 >= 0 ? y2-1 : 0] == _nodes[x2, y2].PreviousStep)
            {
                steps.Add("down");
                y2--;
            }
            else if (_nodes[x2, y2+1 < _nodes.GetLength(1) ? y2+1 : _nodes.GetLength(1)-1] == _nodes[x2, y2].PreviousStep)
            {
                steps.Add("up");
                y2++;
            }
            else if (_nodes[x2-1 >= 0 ? x2-1 : 0, y2] == _nodes[x2, y2].PreviousStep)
            {
                steps.Add("right");
                x2--;
            }
            else if (_nodes[x2+1 < _nodes.GetLength(0) ? x2+1 : _nodes.GetLength(0)-1, y2] == _nodes[x2, y2].PreviousStep)
            {
                steps.Add("left");
                x2++;
            }
            else if (_nodes[x2-1 >= 0 ? x2-1 : 0, y2-1 >= 0 ? y2-1 : 0] == _nodes[x2, y2].PreviousStep)
            {
                steps.Add("down-right");
                x2--;
                y2--;
            }
            else if (_nodes[x2+1 < _nodes.GetLength(0) ? x2+1 : _nodes.GetLength(0)-1, y2+1 < _nodes.GetLength(1) ? y2+1 : _nodes.GetLength(1)-1] == _nodes[x2, y2].PreviousStep)
            {
                steps.Add("up-left");
                x2++;
                y2++;
            }
            else if (_nodes[x2-1 >= 0 ? x2-1 : 0, y2+1 < _nodes.GetLength(1) ? y2+1 : _nodes.GetLength(1)-1] == _nodes[x2, y2].PreviousStep)
            {
                steps.Add("up-right");
                x2--;
                y2++;
            }
            else if (_nodes[x2+1 < _nodes.GetLength(0) ? x2+1 : _nodes.GetLength(0)-1, y2-1 >= 0 ? y2-1 : 0] == _nodes[x2, y2].PreviousStep)
            {
                steps.Add("down-left");
                x2++;
                y2--;
            }

            if (x1 == x2 && y1 == y2)
                finish = true;
        }

        for (var i = steps.Count - 1; i >= 0; i--)
        {
            output += steps[i] + "\n";
        }
        return output;
    }

    private void ResetMarks()
    {
        for (var i = 0; i < _nodes.GetLength(1); i++)
        for (var j = 0; j < _nodes.GetLength(0); j++)
        {
            _nodes[j, i].Mark = float.PositiveInfinity;
            _nodes[j, i].Visited = false;
        }
    }

    private Node MinMark()
    {
        var min = float.PositiveInfinity;
        Node result = null;
        for (var i = 0; i < _nodes.GetLength(1); i++)
        for (var j = 0; j < _nodes.GetLength(0); j++)
            if (_nodes[j, i].Mark < min && !_nodes[j, i].Visited)
            {
                min = _nodes[j, i].Mark;
                result = _nodes[j, i];
            }
        return result;
    }
}

internal class Node
{
    private List<Line> _lines = new List<Line>();
    public float Mark { get; set; }
    public bool Visited { get; set; }
    public Node PreviousStep { get; private set; }

    public void AddLine(Line line)
    {
        _lines.Add(line);
    }

    public void MarkContacts()
    {
        foreach (var line in _lines.Where(line => line.End.Mark > Mark + line.Weight))
        {
            line.End.Mark = Mark + line.Weight;
            line.End.PreviousStep = this;
        }

        Visited = true;
    }
}

internal class Line
{
    public float Weight { get; }
    public Node End { get; }

    public Line(float weight, Node end)
    {
        Weight = weight;
        End = end;
    }
    
}

