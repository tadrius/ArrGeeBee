using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraPositioner : MonoBehaviour
{
    [SerializeField] float xOffset = 0f;
    [SerializeField] float yOffset = 10f;

    public void CenterCamera(TileGrid grid)
    {
        transform.position = new(
            ((grid.Cols - 1) * grid.Scale) / 2f + xOffset, 
            ((grid.Rows - 1) * grid.Scale) / 2f + yOffset, 
            transform.position.z);
    }
}
