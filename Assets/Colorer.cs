using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Colorer : MonoBehaviour
{

    [SerializeField][Range(0f, 1f)] float red = 1f;
    [SerializeField][Range(0f, 1f)] float green = 0f;
    [SerializeField][Range(0f, 1f)] float blue = 0f;

    [SerializeField][Range(0f, 1f)] float highlightMultiplier = .5f; 

    public void ColorTile(Tile tile)
    {
        tile.GetComponent<TileColor>().AddColor(red, green, blue);
    }

    public void HighlightTile(Tile tile)
    {
        tile.GetComponent<TileColor>().Highlight(red * highlightMultiplier, green * highlightMultiplier, blue * highlightMultiplier);
    }

    public void RemoveHighlight(Tile tile)
    {
        tile.GetComponent<TileColor>().RemoveHighlight();
    }
}
