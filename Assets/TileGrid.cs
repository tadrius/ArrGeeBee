using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGrid : MonoBehaviour
{

    [SerializeField] int cols = 10;
    [SerializeField] int rows = 10;
    [SerializeField] float scale = 1f;

    [SerializeField] Tile tilePrefab;

    public int Cols { get { return cols; } }
    public int Rows { get { return rows; } }
    public float Scale { get { return scale; } }

    public void CreateGrid()
    {
        for (int x = 0; x < cols; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                Vector3 position = new (x, y, 0);
                Instantiate(tilePrefab, position * scale, Quaternion.identity, transform);
            }
        }
    }
}
