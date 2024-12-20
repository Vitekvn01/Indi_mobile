using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BuildShopView : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _countCrystall;
    [SerializeField] private TextMeshProUGUI _countWood;

    [SerializeField] private Button _productionBuildButton;
    [SerializeField] private Button _decorationBuildButton;

    [SerializeField] private GameObject _productionBuildPanel;
    [SerializeField] private GameObject _decorationBuildPanel;

    [SerializeField] private GameObject _productionBuildContent;
    [SerializeField] private GameObject _decorationBuildContent;

    [Inject] private IBuildShopManager _buildShopManager;
    [Inject] private IResourceManager _resourceManager;

    private void Awake()
    {
        _productionBuildButton.onClick.AddListener(ShowProductionBuildPanel);
        _decorationBuildButton.onClick.AddListener(ShowDecorationBuildPanel);
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




}
