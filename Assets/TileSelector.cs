using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileSelector : MonoBehaviour
{
    [SerializeField] bool selecting = false;

    bool startR, startG, startB;

    List<Tile> tiles;

    TileGrid grid;

    public bool Selecting { get { return selecting; } }
    public bool StartR { get {  return startR; } }
    public bool StartG { get {  return startG; } }
    public bool StartB { get {  return startB; } }

    private void Awake()
    {
        grid = FindObjectOfType<TileGrid>();
    }

    public void StartSelection(Tile tile)
    {
        if (tile == null) { return; }

        startR = tile.RActive;
        startG = tile.GActive;
        startB = tile.BActive;

        tile.Select();

        tiles = new() { tile };

        selecting = true;
    }

    public void Deselect(Tile previousTile)
    {
        if (tiles.Count <= 1) { return; }
        if (tiles[tiles.Count - 2] == previousTile)
        {
            Tile tile = tiles[tiles.Count - 1];
            grid.SetAdjoiningEdgesActive(previousTile, tile, true);
            tile.Deselect();
            tiles.Remove(tile);
        }
    }

    public bool Select(Tile tile)
    {
        Tile previousTile = tiles[tiles.Count - 1];
        if (grid.AreNeighbors(previousTile, tile)
            && SelectionIsValid(tile)) {
            tile.Select();
            tile.TileBorder.Show();
            grid.SetAdjoiningEdgesActive(previousTile, tile, false);
            tiles.Add(tile);
            return true;
        }
        return false;
    }

    public void EndSelection()
    {
        if (!selecting) { return; }

        selecting = false;
        foreach (Tile tile in tiles)
        {
            tile.Deselect(startR, startG, startB); // TODO - add scoring
        }

        // empty the first tile if other tiles were selected
        if (tiles.Count > 1)
        {
            tiles[0].EmptyTile();
        }
    }

    bool SelectionIsValid(Tile tile)
    {
        return ((startR && !tile.RActive) || (startG && !tile.GActive) || (startB && !tile.BActive));
    }
}