using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;



public class ProductionBuild : MonoBehaviour
{
    [SerializeField] private float _percentProduction;
    [SerializeField] private float _maxProduction;
    [SerializeField] private float _giveTime;
    [SerializeField] private float _amountProduction;
    [SerializeField] private ResourceType _resourceType;

    private float _timer;
    private float _currentProduction;
    [Inject] private IResourceManager _resourceManager;

    public void Update()
    {
        _timer += Time.deltaTime;

        AddProduction();
    }

    public void AddProduction()
    {
        if (_timer > _giveTime)
        {
            _currentProduction += _amountProduction;
            _timer = 0;
        }
    }


}
