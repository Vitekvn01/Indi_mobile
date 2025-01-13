using System;
using System.Collections.Generic;

public interface IBuildShopManager
{
    public event Action OnBuildBuyEvent;
    public event Action OnCancelBuyEvent;
    public void Buy(BuildData buildData);

    public void CancelBuy();

    public List<BuildData> GetProductionBuildDataList();
    public List<BuildData> GetDecorationBuildDataList();
}
