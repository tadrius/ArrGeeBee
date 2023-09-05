using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Tile))]
public class TileColor : MonoBehaviour
{

    SpriteRenderer spriteRenderer;

    [SerializeField] float maxR = .5f;
    [SerializeField] float maxG = .5f;
    [SerializeField] float maxB = .5f;

    float red = 0f;
    float green = 0f;
    float blue = 0f;

    bool highlighted = false;

    public bool Highlighted { get { return highlighted; } }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ApplyRGB(bool r, bool g, bool b)
    {
        if (r) { red = maxR;    } else { red = 0f; }
        if (g) { green = maxG;  } else { green = 0f; }
        if (b) { blue = maxB;   } else { blue = 0f; }
        spriteRenderer.color = new Color(red, green, blue);
    }

    public void Highlight(float redAmount, float greenAmount, float blueAmount)
    {
        if (highlighted) return;
        spriteRenderer.color = new Color(
            Mathf.Min(maxR, red + redAmount),
            Mathf.Min(maxG, green + greenAmount),
            Mathf.Min(maxB, blue + blueAmount));
        highlighted = true;
    }

    public void RemoveHighlight()
    {
        if (!highlighted) return;
        spriteRenderer.color = new Color(red, green, blue);
        highlighted = false;
    }

}
