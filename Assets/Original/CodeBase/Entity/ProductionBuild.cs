using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject.ReflectionBaking.Mono.Cecil;



public class ProductionBuild : MonoBehaviour
{
    [SerializeField] private float _PercentProduction;
    [SerializeField] private float _MaxProduction;
    [SerializeField] private float _GiveTime;
    [SerializeField] private float _AmountProduction;
    [SerializeField] private float _CurrentProduction;
    private IResourceManager _ResourceManager;
    [SerializeField] private ResourceType _ResourceType;
}
