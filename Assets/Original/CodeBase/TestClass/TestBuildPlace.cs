using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBuildPlace : MonoBehaviour
{
    public GridManager _gridManager;
    public GameObject _prefab;
    public GameObject _currentBuild;

    private void Start()
    {
        _currentBuild = Instantiate(_prefab);
    }

    void Update()
    {
        if (_currentBuild != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 snappedPosition = _gridManager.SnapToGrid(hit.point);
                snappedPosition.y += _currentBuild.transform.localScale.y / 2;
                _currentBuild.transform.position = snappedPosition;

                if (Input.GetMouseButtonDown(0))
                {
                    Instantiate(_prefab, snappedPosition, Quaternion.identity);
                }
            }
        }



    }
}
