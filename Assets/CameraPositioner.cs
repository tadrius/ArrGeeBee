using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraPositioner : MonoBehaviour
{
    public void CenterCamera(TileGrid grid)
    {
        transform.position = new(
            ((grid.Cols - 1) * grid.Scale) / 2f, 
            ((grid.Rows - 1) * grid.Scale) / 2f, 
            transform.position.z);
    }
}
