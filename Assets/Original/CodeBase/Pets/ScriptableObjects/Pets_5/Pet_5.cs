using Assets.Original.CodeBase.GatchaSysteam;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pet_5", menuName = "Pet_5", order = 52)]
public class Pet_5 : ScriptableObject,IPet
{
    [SerializeField] private string namePet;
    [SerializeField] private GameObject prefab;
    [SerializeField] private ItemQuality itemQuality = ItemQuality.Legendary;
    [SerializeField] private float produceProcent;

    public string GetName()
    {
        return namePet;
    }

    public GameObject GetPrefab()
    {
        return prefab;
    }
    public ItemQuality GetItemQuality()
    {
        return itemQuality;
    }
}
