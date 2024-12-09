using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pet_5", menuName = "Pet_5", order = 52)]
public class Pet_5 : ScriptableObject
{
    [SerializeField] private string namePet;
    [SerializeField] private GameObject prefab;
    public string GetName()
    {
        return namePet;
    }

    public GameObject GetPrefab()
    {
        return prefab;
    }
}
