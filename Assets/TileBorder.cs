using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBorder : MonoBehaviour
{
    [SerializeField] SpriteRenderer topEdge;
    [SerializeField] SpriteRenderer bottomEdge;
    [SerializeField] SpriteRenderer leftEdge;
    [SerializeField] SpriteRenderer rightEdge;

    public void Hide()
    {
        SetEdgesActive(false);
    }

    public void Show()
    {
        SetEdgesActive(true);
    }

    public void SetEdgesActive(bool active)
    {
        topEdge.enabled = active;
        bottomEdge.enabled = active;
        leftEdge.enabled = active;
        rightEdge.enabled = active;
    }

    public void SetTopEdgeActive(bool active)
    {
        topEdge.enabled = active;
    }

    public void SetBottomEdgeActive(bool active)
    {
        bottomEdge.enabled = active;
    }

    public void SetLeftEdgeActive(bool active)
    {
        leftEdge.enabled = active;
    }

    public void SetRightEdgeActive(bool active)
    {
        rightEdge.enabled = active;
    }

}
