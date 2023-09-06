using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileSelector : MonoBehaviour
{
    [SerializeField] bool selecting = false;

    bool fillR, fillG, fillB;

    List<Tile> tiles;

    TileGrid grid;
    Scoreboard scoreboard;

    public bool Selecting { get { return selecting; } }
    public bool FillR { get {  return fillR; } }
    public bool FillG { get {  return fillG; } }
    public bool FillB { get {  return fillB; } }

    private void Awake()
    {
        grid = FindObjectOfType<TileGrid>();
        scoreboard = FindObjectOfType<Scoreboard>();
    }

    public void StartSelection(Tile tile)
    {
        if (tile == null) { return; }

        fillR = tile.RActive;
        fillG = tile.GActive;
        fillB = tile.BActive;

        tile.Select();

        tiles = new() { tile };

        selecting = true;
        CalculateTileValues();
    }

    void CalculateTileValues()
    {
        foreach (Tile tile in grid.Tiles)
        {
            tile.GetComponent<TileValue>().CalculateValue(fillR, fillG, fillB, tiles.Count);
        }
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

            scoreboard.AddBufferedPoints(-tile.GetComponent<TileValue>().Value);
            CalculateTileValues();
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

            scoreboard.AddBufferedPoints(tile.GetComponent<TileValue>().Value);
            CalculateTileValues();
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
            tile.Deselect(fillR, fillG, fillB); // TODO - add scoring
        }

        // empty the first tile if other tiles were selected
        if (tiles.Count > 1)
        {
            tiles[0].EmptyTile();
        }

        fillR = false;
        fillG = false;
        fillB = false;

        scoreboard.IncreaseScore();
        CalculateTileValues();
    }

    bool SelectionIsValid(Tile tile)
    {
        return ((fillR && !tile.RActive) || (fillG && !tile.GActive) || (fillB && !tile.BActive));
    }
}