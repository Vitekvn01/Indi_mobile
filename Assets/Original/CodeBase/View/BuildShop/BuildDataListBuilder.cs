using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using Zenject;

public class BuildDataListBuilder : MonoBehaviour
{
    [SerializeField] private GameObject _parentObject;
    [SerializeField] private GameObject _buildDataViewPrefab;

    [Inject] private DiContainer _container;

    public void InitList(List<BuildData> buildDatas)
    {
        for (int i = 0; i < buildDatas.Count; i++)
        {
            BuildDataView buildDataView = _container.InstantiatePrefab(_buildDataViewPrefab, _parentObject.transform).GetComponent<BuildDataView>();
            buildDataView.SetBuildData(buildDatas[i]);
            buildDataView.SetImage(buildDatas[i].GetImage());
            buildDataView.SetName(buildDatas[i].GetName());
            buildDataView.SetWoodPrice(buildDatas[i].GetDescription());
            buildDataView.SetCrystalPrice(buildDatas[i].GetCrystalPrice().ToString());
            buildDataView.SetWoodPrice(buildDatas[i].GetWoodPrice().ToString());
        }
    }


}
