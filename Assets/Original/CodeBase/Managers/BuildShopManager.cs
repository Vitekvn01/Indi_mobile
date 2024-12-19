using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BuildShopManager : MonoBehaviour, IBuildShopManager
{
    [SerializeField] private List<BuildData> _prodBuildDataList;

    [Inject] private IBuilder _builder;
    [Inject] private IResourceManager _resourceManager;

    public event Action OnBuyManagerEvent;
    public event Action OnCloseManagerEvent;

    public void Buy()
    {
        throw new NotImplementedException();
    }

    public List<BuildData> GetProductionBuildDataList(List<BuildData> prodBuildDatas)
    {
        return prodBuildDatas;
    }

    public List<BuildData> GetDecorationBuildDataList(List<BuildData> decorBuildDatas)
    {
        return decorBuildDatas;
    }
}
