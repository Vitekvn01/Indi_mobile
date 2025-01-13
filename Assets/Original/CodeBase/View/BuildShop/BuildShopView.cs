using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BuildShopView : WindowView, IBuildShopView
{
    [SerializeField] private Button _productionBuildButton;
    [SerializeField] private Button _decorationBuildButton;

    [SerializeField] private GameObject _productionBuildPanel;
    [SerializeField] private GameObject _decorationBuildPanel;

    [SerializeField] private BuildDataListBuilder _productionBuildDataList;
    [SerializeField] private BuildDataListBuilder _decorationBuildDataList;

    [Inject] private IBuildShopManager _buildShopManager;

    public event Action OnHideViewEvent;

    private void Awake()
    {
        _buildShopManager.OnBuildBuyEvent += Hide;
        _buildShopManager.OnCancelBuyEvent += Show; 

        _productionBuildButton.onClick.AddListener(ShowProductionBuildPanel);
        _decorationBuildButton.onClick.AddListener(ShowDecorationBuildPanel);

        _productionBuildDataList.InitList(_buildShopManager.GetProductionBuildDataList());
        _decorationBuildDataList.InitList(_buildShopManager.GetDecorationBuildDataList());
    }

    private void ShowProductionBuildPanel()
    {
        if (_productionBuildPanel.activeSelf == false)
        {
            _productionBuildPanel.SetActive(true);
        }

        HideDecorationBuildPanel();
    }
    private void ShowDecorationBuildPanel()
    {
        if (_decorationBuildPanel.activeSelf == false)
        {
            _decorationBuildPanel.SetActive(true);
        }

        HideProductionBuildPanel();
    }
    private void HideDecorationBuildPanel()
    {
        if (_decorationBuildPanel.activeSelf == true)
        {
            _decorationBuildPanel.SetActive(false);
        }
    }
    private void HideProductionBuildPanel()
    {
        if (_productionBuildPanel.activeSelf == true)
        {
            _productionBuildPanel.SetActive(false);
        }
    }


    private void OnDestroy()
    {
        _buildShopManager.OnCancelBuyEvent -= Show;
        _buildShopManager.OnBuildBuyEvent -= Hide;
    }

    public void Show()
    {
        ShowPanel();
        Debug.Log("показать панель");
    }

    public void Hide()
    {
        HidePanel();
        OnHideViewEvent?.Invoke();
    }
}
