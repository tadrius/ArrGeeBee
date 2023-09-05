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
                if (!tileSelector.Selecting) // if pointing over tile while not selecting
                {
                    EmptyCurrentTile(); // remove border and highlights of previously pointed at tile
                } else
                {
                    tileSelector.Select(tile);
                }
                currentTile = tile;
                highlighter.HighlightTile(currentTile);
                currentTile.ShowBorder(true);
            }
        }
        else
        {
            EmptyCurrentTile();
        }
    }

    void EmptyCurrentTile()
    {
        if (currentTile != null)
        {
            highlighter.RemoveHighlight(currentTile);
            currentTile.ShowBorder(false);
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
