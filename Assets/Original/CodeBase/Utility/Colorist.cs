using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Colorist
{
    public static void ChangeColor(GameObject gameObject, Color color)
    {
        Renderer[] visualRenderers = gameObject.GetComponentsInChildren<Renderer>();

        foreach (Renderer renderer in visualRenderers)
        {
            renderer.material.color = color;
        }
    }
}
