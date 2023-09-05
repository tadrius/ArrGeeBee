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
            if (tile != null && tile != currentTile)
            {
                // when selecting
                if (tileSelector.Selecting)
                {
                    currentTile = tile;
                    if (currentTile.Selected) { return; }
                    tileSelector.Select(currentTile);
                    highlighter.HighlightTile(currentTile);
                    currentTile.ShowBorder(true);
                }
                // mouse over
                else
                {
                    if (currentTile != null)
                    {
                        highlighter.RemoveHighlight(currentTile);
                        currentTile.ShowBorder(false);
                    }
                    currentTile = tile;
                    highlighter.HighlightTile(currentTile);
                    currentTile.ShowBorder(true);
                }
            }
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
