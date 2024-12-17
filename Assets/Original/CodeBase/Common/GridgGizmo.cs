using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridgGizmo : MonoBehaviour
{
    public float _gridSize;
    private void OnDrawGizmos()
    {
        if (_gridSize <= 0) return;

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
        for (float x = minX; x <= maxX; x += _gridSize)
        {
            Gizmos.DrawLine(new Vector3(x, center.y, minZ), new Vector3(x, center.y, maxZ));
        }

        // Отрисовка линий вдоль Z
        for (float z = minZ; z <= maxZ; z += _gridSize)
        {
            Gizmos.DrawLine(new Vector3(minX, center.y, z), new Vector3(maxX, center.y, z));
        }
    }
}
