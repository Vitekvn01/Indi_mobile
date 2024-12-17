using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGrid
{
    public Vector3 SnapToGrid(Vector3 position);
}
