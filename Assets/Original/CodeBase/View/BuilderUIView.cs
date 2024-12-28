using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BuilderUIView : WindowView
{
    [SerializeField] private Button _intsallButton;
    [SerializeField] private Button _rotateButton;
    [SerializeField] private Button _cancelButton;

    [Inject] private IBuilder _builder;

    private void Awake()
    {
        _builder.OnStartBuildingEvent += ShowPanel;
        _builder.OnClouseBuildingEvent += HidePanel;
        _intsallButton.onClick.AddListener(_builder.Instal);
        _rotateButton.onClick.AddListener(_builder.Rotation);
        _cancelButton.onClick.AddListener(_builder.Cancel);
    }
}
