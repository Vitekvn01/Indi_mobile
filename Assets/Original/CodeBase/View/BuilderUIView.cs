using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BuilderUIView : MonoBehaviour
{
    [SerializeField] private Button _intsallButton;
    [SerializeField] private Button _rotateButton;
    [SerializeField] private Button _cancelButton;

    [Inject] private IBuilder _builder;

    private void Awake()
    {
        _builder.OnBuildingEvent += ShowPanel;
        _builder.OnClouseBuildingEvent += HidePanel;
        _intsallButton.onClick.AddListener(_builder.Instal);
        _rotateButton.onClick.AddListener(_builder.Rotation);
        _cancelButton.onClick.AddListener(_builder.Cancel);
    }

    private void ShowPanel()
    {
        gameObject.SetActive(true);
    }

    private void HidePanel()
    {
        gameObject.SetActive(false);
    }
}
