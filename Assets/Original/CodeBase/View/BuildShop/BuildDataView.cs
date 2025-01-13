using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BuildDataView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _size;
    [SerializeField] private TextMeshProUGUI _crystalPrice;
    [SerializeField] private TextMeshProUGUI _woodPrice;
    [SerializeField] private Button _buyButton;

    [SerializeField] private BuildData _buildData;

    [Inject] private IBuildShopManager _buildShopManager;

    private void Start()
    {
        _buyButton.onClick.AddListener(HoldBuyButton);
    }

    public void SetBuildData(BuildData buildData)
    {
        _buildData = buildData;
    }
    public void SetImage(Image image)
    {
        if (image != null)
        {
            _image = image;
        }
    }

    public void SetName(string name)
    {
        _name.text = name;
    }

    public void SetSize(string size)
    {
        _size.text = size;
    }

    public void SetCrystalPrice(string price)
    {
        _crystalPrice.text = price;
    }

    public void SetWoodPrice(string price)
    {
        _woodPrice.text = price;
    }

    private void HoldBuyButton()
    {
        if (_buildData != null)
        {
            if (_buildShopManager != null)
            {
                _buildShopManager.Buy(_buildData);
            }
            else
            {
                Debug.Log("BuildShop == null");
            }

        }
    }
}
