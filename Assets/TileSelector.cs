using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelector : MonoBehaviour
{
    [SerializeField] bool selecting = false;

    Tile startTile;
    bool startR, startG, startB;

    List<Tile> tiles;
    
    public bool Selecting { get { return selecting; } }

    public void StartSelection(Tile tile)
    {
        startTile = tile;
        startR = tile.RActive;
        startG = tile.GActive;
        startB = tile.BActive;

        tiles = new();
        selecting = true;
    }

    public void Select(Tile tile)
    {
        tile.Select();
        tiles.Add(tile);
    }

    public void EndSelection()
    {
        selecting = false;
        startTile.Unselect(startR, startG, startB);
        startTile = null;
        foreach(Tile tile in tiles)
        {
            tile.Unselect(startR, startG, startB);
        }
    }
}
