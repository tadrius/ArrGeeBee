using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerActions))]
[RequireComponent(typeof(Colorer))]
public class Player : MonoBehaviour
{

    Tile currentTile;
    PlayerActions actions;
    Colorer colorer;

    private void Awake()
    {
        actions = GetComponent<PlayerActions>();
        colorer = GetComponent<Colorer>();
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
                if (currentTile != null)
                {
                    colorer.RemoveHighlight(currentTile);
                }
                currentTile = tile;
                colorer.HighlightTile(currentTile);
            }
        }
    }

    void Click()
    {
        colorer.ColorTile(currentTile);
        if (currentTile.IsComplete())
        {
            // TODO - score
            // TODO - reset tile
            currentTile.ResetTile();
        }
    }
}
