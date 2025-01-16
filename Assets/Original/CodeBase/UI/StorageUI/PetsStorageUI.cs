using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PetsStorageUI : MonoBehaviour
{
    [SerializeField] private GameObject petsStoragePanelPrefab;

    [Inject] private SystemInteractionUI systemInteractionUI;
    [Inject] DiContainer container;

    private GameObject petsStoragePanelObject;
    private MainStoragePanelUI mainStoragePanelUI;


    public void CreatStoragePanel()
    {
        petsStoragePanelObject = container.InstantiatePrefab(petsStoragePanelPrefab,gameObject.transform);
        petsStoragePanelObject.TryGetComponent<MainStoragePanelUI>(out mainStoragePanelUI);
        mainStoragePanelUI.LoadPanel();
        mainStoragePanelUI.EventCloseStoragePanel += closePetsStorageUI;
        systemInteractionUI.setUnInteract();
    }

    private void closePetsStorageUI()
    {
        systemInteractionUI.setInteract();
        Destroy(petsStoragePanelObject);
    }
}
