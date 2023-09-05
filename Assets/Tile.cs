using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TileColor))]
public class Tile : MonoBehaviour
{
    bool selected = false;
    bool rActive = false;
    bool gActive = false;
    bool bActive = false;

    TileColor tileColor;
    TileBorder tileBorder;
    Vector2Int coordinates;

    public bool Selected { get { return selected; } }
    public bool RActive { get { return rActive; } }
    public bool GActive { get { return gActive; } }
    public bool BActive { get { return bActive; } }

    public TileBorder TileBorder { get { return tileBorder; } }

    public Vector2Int Coordinates { get { return coordinates; } }

    private void Awake()
    {
        tileColor = GetComponent<TileColor>();
        tileBorder = GetComponent<TileBorder>();
    }

    private void Start()
    {
        ResetTile();
    }

    public void Select()
    {
        selected = true;
    }

    public void Deselect(bool activateR, bool activateG, bool activateB)
    {
        rActive = rActive || activateR;
        gActive = gActive || activateG;
        bActive = bActive || activateB;

        Deselect();

        if (IsComplete())
        {
            ResetTile();
        }
    }

    public void Deselect()
    {
        selected = false;

        tileColor.RemoveHighlight();
        TileBorder.Hide();
        tileColor.ApplyRGB(rActive, gActive, bActive);
    }

    public bool IsComplete()
    {
        return rActive && gActive && bActive;
    }

    private void ResetTile()
    {
        rActive = 1 == Random.Range(0, 2);
        gActive = 1 == Random.Range(0, 2);
        bActive = 1 == Random.Range(0, 2);

        if (rActive && gActive && bActive)
        {
            int deactivateIndex = Random.Range(0, 3);
            if (deactivateIndex == 0)
            {
                rActive = false;
            } else if (deactivateIndex == 1)
            {
                gActive = false;
            } else
            {
                bActive = false;
            }
        }
        tileColor.ApplyRGB(rActive, gActive, bActive);
    }

    public void EmptyTile()
    {
        rActive = false;
        gActive = false;
        bActive = false;

        tileColor.ApplyRGB(rActive, gActive, bActive);
    }

    public void SetCoordinates(Vector2Int coordinates)
    {
        this.coordinates = coordinates;
    }
}
