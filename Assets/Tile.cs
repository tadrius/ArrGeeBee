using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TileColor))]
public class Tile : MonoBehaviour
{

    TileColor color;

    private void Awake()
    {
        color = GetComponent<TileColor>();
    }

    public bool IsComplete()
    {
        if (color.IsWhite()) return true;
        return false;
    }

    public void ResetTile()
    {
        color.SetRandomColor();
    }

}
