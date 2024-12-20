using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class CountCrystalText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countText;

    [Inject] private IResourceManager _resourceManager;

    private void Awake()
    {
        _resourceManager.OnCountCrystallEvent += OnCrystalCountChanged;
    }

    private void OnCrystalCountChanged(float count)
    {
        _countText.text = count.ToString();
    }
}
