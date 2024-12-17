using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuildShopManager
{
    public event Action OnBuyManagerEvent;
    public event Action OnCloseManagerEvent;

    public void Buy();

    public List<BuildData> GetBuildDataList();

}
