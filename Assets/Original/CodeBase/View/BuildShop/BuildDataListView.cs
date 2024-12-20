using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildDataListView : MonoBehaviour
{
    [SerializeField] private GameObject _parentObject;
    [SerializeField] private GameObject _buildDataViewPrefab;
    private void InitList(List<BuildData> buildDatas)
    {
        for (int i = 0; i < buildDatas.Count; i++)
        {
            BuildDataView buildDataView = Instantiate(_buildDataViewPrefab, _parentObject.transform).GetComponent<BuildDataView>();
            buildDataView.SetImage(buildDatas[i].GetImage());
            buildDataView.SetName(buildDatas[i].GetName());
            buildDataView.SetWoodPrice(buildDatas[i].GetDescription());
            buildDataView.SetCrystalPrice(buildDatas[i].GetCrystalPrice().ToString());
            buildDataView.SetWoodPrice(buildDatas[i].GetWoodPrice().ToString());
        }
    }
}
