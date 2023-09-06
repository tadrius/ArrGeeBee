using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGrid : MonoBehaviour
{

    [SerializeField] int cols = 10;
    [SerializeField] int rows = 10;
    [SerializeField] float scale = 1f;

    [SerializeField] Tile tilePrefab;

    List<Tile> tiles = new List<Tile>();

    public int Cols { get { return cols; } }
    public int Rows { get { return rows; } }
    public float Scale { get { return scale; } }
    public List<Tile> Tiles { get {  return tiles; } }

    public void CreateGrid()
    {
        for (int x = 0; x < cols; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                Vector3 position = new (x, y, 0);
                Tile tile = Instantiate(tilePrefab, position, Quaternion.identity, transform);
                tile.SetCoordinates(new Vector2Int(x, y));
                tiles.Add(tile);
            }
        }
        transform.localScale *= scale;
    }
    public bool AreNeighbors(Tile tile1, Tile tile2)
    {
        int xDistance = Mathf.Abs(tile1.Coordinates.x - tile2.Coordinates.x);
        int yDistance = Mathf.Abs(tile1.Coordinates.y - tile2.Coordinates.y);
        return (xDistance + yDistance) == 1;
    }

    public void SetAdjoiningEdgesActive(Tile tile1, Tile tile2, bool active)
    {
        int xDifference = tile1.Coordinates.x - tile2.Coordinates.x;
        if (xDifference == -1)
        {
            tile1.GetComponent<TileBorder>().SetRightEdgeActive(active);
            tile2.GetComponent<TileBorder>().SetLeftEdgeActive(active);
        }
        else if (xDifference == 1)
        {
            tile1.GetComponent<TileBorder>().SetLeftEdgeActive(active);
            tile2.GetComponent<TileBorder>().SetRightEdgeActive(active);
        }
        else
        {
            int yDifference = tile1.Coordinates.y - tile2.Coordinates.y;
            if (yDifference == -1)
            {
                tile1.GetComponent<TileBorder>().SetTopEdgeActive(active);
                tile2.GetComponent<TileBorder>().SetBottomEdgeActive(active);
            }
            else if (yDifference == 1)
            {
                tile1.GetComponent<TileBorder>().SetBottomEdgeActive(active);
                tile2.GetComponent<TileBorder>().SetTopEdgeActive(active);
            }
        }
    }

}
