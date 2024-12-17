using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Grid : IGrid
{
    private float _gridSize = 1.0f;

    public Vector3 SnapToGrid(Vector3 position)
    {
        float x = Mathf.Round(position.x / _gridSize) * _gridSize;
        float z = Mathf.Round(position.z / _gridSize) * _gridSize;
        
        return new Vector3(x, position.y, z);
    }
}

