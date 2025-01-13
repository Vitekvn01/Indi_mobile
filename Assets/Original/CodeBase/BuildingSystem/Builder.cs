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

    public event Action OnStartBuildingEvent;
    public event Action OnClouseBuildingEvent;

    public event Action OnCancelBuildingEvent;
    public event Action OnCompleteBuildingEvent;

    private void Start()
    {
        _mobileInput.ClickDown += OnClickDown;
        _mobileInput.Drag += OnDrag;
        _mobileInput.ClickUp += OnClickUp;
    }

    public void Instal()
    {
        if (_currentBuildInstal != null)
        {
            _currentBuildInstal = null;
            OnCompleteBuildingEvent.Invoke();
        }
    }

    public void SetCurrentBuild(GameObject build)
    {
        _currentBuildInstal = build;
    }

    public void Cancel()
    {
        Destroy(_currentBuildInstal);
        _currentBuildInstal = null;
        OnCancelBuildingEvent?.Invoke();
        OnClouseBuildingEvent?.Invoke();
    }

    public void Rotation()
    {
        if (_currentBuildInstal != null)
        {
            _currentBuildInstal.transform.Rotate(0, 90, 0);
            Debug.Log("rotation");
        }
    }

    public void CreateBuild(GameObject buildPrefab)
    {
        _buildPrefab = buildPrefab;
        Spawn();
        OnStartBuildingEvent?.Invoke();
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




}
