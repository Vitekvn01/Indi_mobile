using Assets.Original.CodeBase.GatchaSysteam;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pet_4", menuName = "Pet_4", order = 51)]
public class Pet_4 : ScriptableObject,IPet
{
    [SerializeField] private string namePet;
    [SerializeField] private string petType;
    [SerializeField] private GameObject prefab;
    [SerializeField] private ItemQuality itemQuality = ItemQuality.Epic;
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

    public string GetPetType()
    {
        return petType;
    }
}
