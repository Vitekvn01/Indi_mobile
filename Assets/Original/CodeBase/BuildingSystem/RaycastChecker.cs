using UnityEngine;

public class RaycastChecker : IRaycastChecker
{

    public Vector3 HitPostion { get; private set; }
    public GameObject HitObject { get; private set; }

    public Vector3 GetHitPos(Vector3 ScreenPos)
    {
        Ray ray = Camera.main.ScreenPointToRay(ScreenPos);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.Log(hit.point);
            return hit.point;
        }
        else
        {
            Debug.Log("HitPos = Zero");
            return Vector3.zero;
        }
    }
}
