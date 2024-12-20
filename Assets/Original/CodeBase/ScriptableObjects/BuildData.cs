using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Build", menuName = "Build")]
public class BuildData : ScriptableObject
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private int _crystalPrice;
    [SerializeField] private int _woodPrice;
    [SerializeField] private Image _image;

    public Image GetImage() 
    { 
        return _image; 
    }

    public GameObject GetPrefab()
    {
        return _prefab;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetCrystalPrice()
    {
        return _crystalPrice;
    }

    public int GetWoodPrice()
    {
        return _woodPrice;
    }
}
