using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Route", menuName = "Route", order = 53)]
public class Route : ScriptableObject
{
    [SerializeField] private List<Transform> points = new List<Transform>();

    public Transform getPoint(int number)
    {
        if(number < points.Count)
        {
            return points[number];
        }

        return null;
    }

    public int checkCountPoints()
    {
        return points.Count;
    }
}
