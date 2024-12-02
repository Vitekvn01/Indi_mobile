using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject.ReflectionBaking.Mono.Cecil;

enum ResourceType
{
    Wood = 0,
    Cristals = 1,
}

public class ProductionBuild : MonoBehaviour
{
    [SerializeField] private float _PercentProduction;
    [SerializeField] private float _MaxProduction;
    [SerializeField] private float _GiveTime;
    [SerializeField] private float _AmountProduction;
    [SerializeField] private float _CurrentProduction;
    [SerializeField] private ResourceType _ResourceType;
}
