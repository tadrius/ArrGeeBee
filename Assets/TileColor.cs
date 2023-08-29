using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Tile))]
public class TileColor : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    float red = 0f;
    float green = 0f;
    float blue = 0f;
    bool highlighted = false;

    public bool Highlighted { get { return highlighted; } }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        SetRandomColor();
    }

    public void SetRandomColor()
    {
        red = Random.Range(0, 2); green = Random.Range(0, 2); blue = Random.Range(0, 2);
        while (IsWhite())
        {
            red = Random.Range(0, 2); green = Random.Range(0, 2); blue = Random.Range(0, 2);
        }
        spriteRenderer.color = new Color(red, green, blue);
    }

    public void AddColor(float r, float g, float b)
    {
        red = Mathf.Min(red + r, 1f);
        green = Mathf.Min(green + g, 1f);
        blue = Mathf.Min(blue + b, 1f);
        spriteRenderer.color = new Color(red, green, blue);
    }

    public void Highlight(float redAmount, float greenAmount, float blueAmount)
    {
        if (highlighted) return;
        spriteRenderer.color = new Color(red + redAmount, green + greenAmount, blue + blueAmount);
        highlighted = true;
    }

    public void RemoveHighlight()
    {
        if (!highlighted) return;
        spriteRenderer.color = new Color(red, green, blue);
        highlighted = false;
    }

    public bool IsWhite()
    {
        if (red >= 1f && green >= 1f &&  blue >= 1f) return true;
        return false;
    }

}
