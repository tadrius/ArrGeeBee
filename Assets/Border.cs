using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    [SerializeField] GameObject topEdge;
    [SerializeField] GameObject bottomEdge;
    [SerializeField] GameObject leftEdge;
    [SerializeField] GameObject rightEdge;

    public void SetEdgesActive(bool active)
    {
        topEdge.SetActive(active);
        bottomEdge.SetActive(active);
        leftEdge.SetActive(active);
        rightEdge.SetActive(active);
    }

    public void SetTopEdgeActive(bool active)
    {
        topEdge.SetActive(active);
    }

    public void SetBottomEdgeActive(bool active)
    {
        bottomEdge.SetActive(active);
    }

    public void SetLeftEdgeActive(bool active)
    {
        leftEdge.SetActive(active);
    }

    public void SetRightEdgeActive(bool active)
    {
        rightEdge.SetActive(active);
    }

}
