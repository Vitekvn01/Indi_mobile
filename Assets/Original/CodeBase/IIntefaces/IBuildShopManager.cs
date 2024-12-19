using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuildShopManager
{
    public event Action OnBuyManagerEvent;
    public event Action OnCloseManagerEvent;

    public void Buy();

    public List<BuildData> GetProductionBuildDataList(List<BuildData> prodBuildDatas);
    public List<BuildData> GetDecorationBuildDataList(List<BuildData> decorBuildDatas);
}
