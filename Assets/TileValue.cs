using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TileValue : MonoBehaviour
{
    bool valueLocked = false;
    int value = 0;

    Tile tile;
    TMP_Text valueLabel;

    public bool ValueLocked { get { return valueLocked; } set {  valueLocked = value; } }
    public int Value { get { return value; } }

    private void Awake()
    {
        tile = GetComponent<Tile>();
        valueLabel = GetComponentInChildren<TMP_Text>();

        UpdateLabel();
    }

    public void CalculateValue(bool fillR, bool fillG, bool fillB, int multiplier)
    {
        if (valueLocked) { return; }
        value = 0;
        // tiles are worth more points for needing more available fill channels
        // and are worth less for unused fill channels
        if (fillR)
        {
            if (tile.RActive)
            {
                value -= 2;
            }
            else
            {
                value += 3;
            }
        }
        if (fillG)
        {
            if (tile.GActive)
            {
                value -= 2;
            }
            else
            {
                value += 3;
            }
        }
        if (fillB)
        {
            if (tile.BActive)
            {
                value -= 2;
            }
            else
            {
                value += 3;
            }
        }
        value *= multiplier;
        UpdateLabel();
    }

    void UpdateLabel()
    {
        if (value <= 0)
        {
            valueLabel.text = "";
        } else
        {
            valueLabel.text = $"{value}";
        }
    }
}
