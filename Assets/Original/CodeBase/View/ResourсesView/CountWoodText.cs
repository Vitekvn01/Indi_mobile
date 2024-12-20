using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class CountWoodText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countText;

    [Inject] private IResourceManager _resourceManager;

    private void Awake()
    {
        _resourceManager.OnCountWoodEvent += OnWoodCountChanged;
    }


    private void OnWoodCountChanged(float count)
    {
        _countText.text = count.ToString();
    }
}
