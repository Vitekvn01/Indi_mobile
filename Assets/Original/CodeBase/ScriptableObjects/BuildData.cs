using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Build", menuName = "Build")]
public class BuildData : ScriptableObject
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private string _name;
    [SerializeField] private string _description;

}
