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

        Gizmos.color = Color.red;

        // Центр сетки
        Vector3 center = transform.position;
        center.y += transform.localScale.y / 2;
        // Вычисление границ сетки
        float extentX = transform.localScale.x / 2f;
        float extentZ = transform.localScale.z / 2f;

        // Минимальные и максимальные координаты сетки
        float minX = center.x - extentX;
        float maxX = center.x + extentX;
        float minZ = center.z - extentZ;
        float maxZ = center.z + extentZ;

        // Отрисовка линий вдоль X
        for (float x = minX; x <= maxX; x += gridSize)
        {
            Gizmos.DrawLine(new Vector3(x, center.y, minZ), new Vector3(x, center.y , maxZ));
        }

        // Отрисовка линий вдоль Z
        for (float z = minZ; z <= maxZ; z += gridSize)
        {
            Gizmos.DrawLine(new Vector3(minX, center.y, z), new Vector3(maxX, center.y, z));
        }
    }
}

