using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TileColor))]
public class Tile : MonoBehaviour
{

    [SerializeField] GameObject border;

    TileColor color;

    private void Awake()
    {
        color = GetComponent<TileColor>();
    }

    public void ShowBorder(bool show)
    {
        border.SetActive(show);
    }

    public bool IsComplete()
    {
        if (color.IsWhite()) return true;
        return false;
    }

    public void ResetTile()
    {
        color.SetRandomColor();
    }

}
