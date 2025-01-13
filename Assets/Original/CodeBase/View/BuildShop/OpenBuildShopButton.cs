using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class OpenBuildShopButton : WindowView
{
    private Button button;

    [Inject] private IBuildShopView _buildShopView;

    private void Awake()
    {
        _buildShopView.OnHideViewEvent += ShowPanel;

        button = GetComponent<Button>();
        button.onClick.AddListener(_buildShopView.Show);
        button.onClick.AddListener(HidePanel);
    }

    private void OnDestroy()
    {
        _buildShopView.OnHideViewEvent -= ShowPanel;
        button.onClick.RemoveAllListeners();
    }
}
