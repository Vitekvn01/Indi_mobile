using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildDataView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _size;
    [SerializeField] private TextMeshProUGUI _crystalPrice;
    [SerializeField] private TextMeshProUGUI _woodPrice;

    public void SetImage(Image image)
    {
        _image = image;
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
}
