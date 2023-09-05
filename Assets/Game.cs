using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    TileGrid grid;
    Camera cam;

    private void Awake()
    {
        grid = FindObjectOfType<TileGrid>();
        cam = FindObjectOfType<Camera>();

        grid.CreateGrid();
        cam.GetComponent<CameraPositioner>().CenterCamera(grid);
    }
}
