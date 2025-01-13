using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PetsStorageUI : MonoBehaviour
{
    [SerializeField] private GameObject petsStoragePanelPrefab;
    [Inject] DiContainer container;

    private GameObject petsStoragePanelObject;

    public void CreatStoragePanel()
    {
        petsStoragePanelObject = container.InstantiatePrefab(petsStoragePanelPrefab,gameObject.transform);
    }
}
