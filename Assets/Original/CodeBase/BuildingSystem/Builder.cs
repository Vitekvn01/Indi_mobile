using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class Builder : MonoBehaviour, IBuilder
{
    [Inject] private IInput _mobileInput;
    [Inject] private IRaycastChecker _raycastChecker;
    [Inject] private IGrid _gridManager;

    private Vector3 _lastDragPosition;


    [SerializeField] private GameObject _buildPrefab;
    [SerializeField] private GameObject _currentBuildInstal;

    public event Action OnBuildingEvent;
    public event Action OnClouseBuildingEvent;

    private void Start()
    {
        OnBuildingEvent.Invoke();

        _mobileInput.ClickDown += OnClickDown;
        _mobileInput.Drag += OnDrag;
        _mobileInput.ClickUp += OnClickUp;

        Spawn();
    }

    public void Instal()
    {
        _currentBuildInstal = null;
        OnBuildingEvent.Invoke();
    }

    private void OnClickDown(Vector3 position)
    {

        Debug.Log($"Click down at position: {position}");
        // Реализуйте вашу логику для обработки нажатия 
    }

    private void OnDrag(Vector3 position)
    {
        _lastDragPosition = position;
    }

    private void OnClickUp(Vector3 position)
    {
        Debug.Log($"Click up at position: {position}");
        // Реализуйте вашу логику для обработки завершения нажатия
    }


    public void SetBuild(GameObject buildPrefab)
    {
        _buildPrefab = buildPrefab;
        OnBuildingEvent.Invoke();
    }

    private void Update()
    {
        SelectionPos();
    }

    private void SelectionPos()
    {
        if (_currentBuildInstal != null)
        {
            Vector3 pos = _gridManager.SnapToGrid(_raycastChecker.GetHitPos(_lastDragPosition));
            pos.y += _currentBuildInstal.transform.localScale.y / 2;
            _currentBuildInstal.transform.position = pos;
        }
    }

    private void Spawn()
    {
        _currentBuildInstal = Instantiate(_buildPrefab);
    }

    public void Cancel()
    {
        Destroy(_currentBuildInstal);
        _currentBuildInstal = null;
        OnBuildingEvent.Invoke();
    }

    public void Rotation()
    {
        if (_currentBuildInstal != null)
        {
            _currentBuildInstal.transform.Rotate(0,90,0);
        }
    }
}
