using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pet_4", menuName = "Pet_4", order = 51)]
public class Pet_4 : ScriptableObject
{
    [SerializeField] private string name;

    public string GetName()
    {
        return name;
    }
}