using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRaycastChecker
{
    public Vector3 GetHitPos(Vector3 ScreenPos);
}
