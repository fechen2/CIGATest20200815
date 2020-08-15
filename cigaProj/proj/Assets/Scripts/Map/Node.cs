using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum CellType
{
    None
}
public class Node
{
    public Vector2Int position;

    public CellType cellType;

    public Node(Vector2Int position, CellType cellType)
    {
        this.position = position;
        this.cellType = cellType;
    }

    public override bool Equals(object obj)
    {
        Node other = obj as Node;
        return position == other.position;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}