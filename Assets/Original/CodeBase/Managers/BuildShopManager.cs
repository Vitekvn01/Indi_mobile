using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BuildShopManager : MonoBehaviour, IBuildShopManager
{
    [SerializeField] private List<BuildData> _prodBuildDataList;
    [SerializeField] private List<BuildData> _decorBuildDataList;

    [Inject] private IBuilder _builder;
    [Inject] private IResourceManager _resourceManager;

    private BuildData _currentBuildData;

    public event Action OnBuildBuyEvent;
    public event Action OnCancelBuyEvent;

    public void Buy(BuildData buildData)
    {
        if (_resourceManager.CheckEnoughResource(ResourceType.Cristals, (float)buildData.GetCrystalPrice())
               && _resourceManager.CheckEnoughResource(ResourceType.Wood, (float)buildData.GetWoodPrice()))
        {
            OnBuildBuyEvent?.Invoke();
            _currentBuildData = buildData;
            _builder.CreateBuild(buildData.GetPrefab());
            SubBuildingEvent();
            RemoveResources(buildData);
        }
        else
        {
            Debug.Log("Нет ресов");
        }
    }

    private void SubBuildingEvent()
    {
        _builder.OnCancelBuildingEvent += CancelBuy;
        _builder.OnCompleteBuildingEvent += UnsubCancelBuildingEvent;
    }

    private void UnsubCancelBuildingEvent()
    {
        _builder.OnCancelBuildingEvent -= CancelBuy;
    }

    public void CancelBuy()
    {
        OnCancelBuyEvent?.Invoke();
        AddResources();
        UnsubCancelBuildingEvent();
    }

    public List<BuildData> GetProductionBuildDataList()
    {
        return _prodBuildDataList;
    }

    public List<BuildData> GetDecorationBuildDataList()
    {
        return _decorBuildDataList;
    }

    private void RemoveResources(BuildData buildData)
    {
        _resourceManager.RemoveResource(ResourceType.Cristals, (float)buildData.GetCrystalPrice());
        _resourceManager.RemoveResource(ResourceType.Wood, (float)buildData.GetWoodPrice());
    }

    private void AddResources()
    {
        _resourceManager.AddResource(ResourceType.Cristals, (float)_currentBuildData.GetCrystalPrice());
        _resourceManager.AddResource(ResourceType.Wood, (float)_currentBuildData.GetWoodPrice());
    }

}
