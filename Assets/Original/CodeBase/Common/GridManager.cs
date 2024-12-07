using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GridManager : MonoBehaviour
{
    public float gridSize = 1.0f;
    private float gridExtentX;   
    private float gridExtentZ;   

    private void UpdateGridExtents()
    {
        gridExtentX = transform.localScale.x / 2f;
        gridExtentZ = transform.localScale.z / 2f;
    }


    public Vector3 SnapToGrid(Vector3 position)
    {
        float x = Mathf.Round(position.x / gridSize) * gridSize;
        float y = Mathf.Round(position.y / gridSize) * gridSize;
        float z = Mathf.Round(position.z / gridSize) * gridSize;
        
        return new Vector3(x, y, z);
    }


    private void OnDrawGizmos()
    {
        if (gridSize <= 0) return;

        Gizmos.color = Color.gray;

        UpdateGridExtents();

        Vector3 position = transform.position;

        // Отрисовка линий сетки вдоль X
        for (float x = -gridExtentX; x <= gridExtentX; x += gridSize)
        {
            Gizmos.DrawLine(
                new Vector3(position.x + x, position.y + transform.localScale.y / 2, position.z - gridExtentZ),
                new Vector3(position.x + x, position.y + transform.localScale.y/2, position.z + gridExtentZ)
            );
        }

        // Отрисовка линий сетки вдоль Z
        for (float z = -gridExtentZ; z <= gridExtentZ; z += gridSize)
        {
            Gizmos.DrawLine(
                new Vector3(position.x - gridExtentX, position.y + transform.localScale.y/2, position.z + z),
                new Vector3(position.x + gridExtentX, position.y + transform.localScale.y/2, position.z + z)
            );
        }
    }
}
