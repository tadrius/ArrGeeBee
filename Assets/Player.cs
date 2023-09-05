using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerActions))]
[RequireComponent(typeof(Highlighter))]
[RequireComponent(typeof(TileSelector))]
public class Player : MonoBehaviour
{

    Tile currentTile;

    PlayerActions actions;
    Highlighter highlighter;
    TileSelector tileSelector;

    private void Awake()
    {
        actions = GetComponent<PlayerActions>();
        highlighter = GetComponent<Highlighter>();
        tileSelector = GetComponent<TileSelector>();
    }

    void FixedUpdate()
    {
        if (actions.Pointed)
        {
            actions.Pointed = false;
            Point();
        }
        if (actions.Clicked)
        {
            actions.Clicked = false;
            Click();
        }
    }

    void Point()
    {
        RaycastHit2D hit = actions.RaycastFromPointer();
        if (hit)
        {
            Tile tile = hit.transform.GetComponent<Tile>();
            if (tile == currentTile || tile.Selected) { return; }
            else 
            {
                if (!tileSelector.Selecting) // if not selecting
                {
                    DropCurrentTile(); // remove border and highlights of previous tile
                    highlighter.HighlightTile(tile);
                    tile.TileBorder.Show();
                } 
                else if (tileSelector.Select(tile)) // if successful selection
                {
                    highlighter.HighlightTile(tile);
                }
                currentTile = tile;
            }
        }
        else if (!tileSelector.Selecting)
        {
            DropCurrentTile();
        }
    }

    void DropCurrentTile()
    {
        if (currentTile != null)
        {
            highlighter.RemoveHighlight(currentTile);
            currentTile.TileBorder.Hide();
            currentTile = null;
        }
    }

    void Click()
    {
        if (actions.PointerDown && currentTile != null)
        {
            tileSelector.StartSelection(currentTile);
        } else
        {
            tileSelector.EndSelection();
        }
    }
}
