using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Highlighter : MonoBehaviour
{

    [SerializeField][Range(0f, 1f)] float defaultRed = 1f;
    [SerializeField][Range(0f, 1f)] float defaultGreen = 1f;
    [SerializeField][Range(0f, 1f)] float defaultBlue = 1f;

    [SerializeField][Range(0f, 1f)] float highlightMultiplier = .5f;

    TileSelector tileSelector;

    private void Awake()
    {
        tileSelector = GetComponent<TileSelector>();
    }

    public void HighlightTile(Tile tile)
    {
        if (tileSelector.Selecting)
        {
            float red = tileSelector.FillR ? 1f : 0f;
            float green = tileSelector.FillG ? 1f : 0f;
            float blue = tileSelector.FillB ? 1f : 0f;
            HighlightTile(tile, red, green, blue);
        } else
        {
            HighlightTile(tile, defaultRed, defaultGreen, defaultBlue);
        }
    }

    public void HighlightTile(Tile tile, float red, float green, float blue)
    {
        tile.GetComponent<TileColor>().Highlight(red * highlightMultiplier, green * highlightMultiplier, blue * highlightMultiplier);
    }

    public void RemoveHighlight(Tile tile)
    {
        tile.GetComponent<TileColor>().RemoveHighlight();
    }
}
