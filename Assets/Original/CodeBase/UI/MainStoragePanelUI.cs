using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Zenject;

public class MainStoragePanelUI : MonoBehaviour
{
    [SerializeField] private GameObject spawnZone;

    [SerializeField] private GameObject petCardPrefab;
    [SerializeField] private GameObject petCardUnkownPrefab;

    [Inject] private PetManager petManager;
    [Inject] DiContainer container;


    private GameObject cardPanel;
    private PetCardManager cardManager;
    private GameObject petCardObject;

    public delegate void StoragePanelUI();
    public event StoragePanelUI EventCloseStoragePanel;

    private int countAllPets;
    private int counterPets;

    public void LoadPanel()
    {
        for (int i = 0; i < petManager.CheckCountEpicPetOpen(); i++)
        {
            petCardObject = spawnCardInSpawnZone();
            cardManager = petCardObject.GetComponent<PetCardManager>();
            cardManager.setName(petManager.getOpenPetEpic(i).GetName());
            cardManager.setQuality(petManager.getOpenPetEpic(i).GetItemQuality().ToString());
            cardManager.setType(petManager.getOpenPetEpic(i).GetPetType());
            cardManager.setCount(petManager.GetCopyCountPet(petManager.getOpenPetEpic(i)).ToString());

            counterPets++;

            cardManager = null;
        }

        for (int i = 0; i < petManager.CheckCountLegendPetOpen(); i++)
        {
            petCardObject = spawnCardInSpawnZone();
            cardManager = petCardObject.GetComponent<PetCardManager>();
            cardManager.setName(petManager.getOpenPetLegend(i).GetName());
            cardManager.setQuality(petManager.getOpenPetLegend(i).GetItemQuality().ToString());
            cardManager.setType(petManager.getOpenPetLegend(i).GetPetType());
            cardManager.setCount(petManager.GetCopyCountPet(petManager.getOpenPetLegend(i)).ToString());

            counterPets++;

            cardManager = null;
        }

        countAllPets = petManager.CheckCountEpicPetDefault() + petManager.CheckCountLegendPetDefault() - counterPets;

        for (int i = 0; i < countAllPets; i++)
        {
            spawnUnkownCard();
        }
    }

    public void ClosePanel()
    {
        EventCloseStoragePanel?.Invoke();
    }

    private GameObject spawnCardInSpawnZone()
    {
        cardPanel = container.InstantiatePrefab(petCardPrefab, spawnZone.transform);

        return cardPanel;
    }

    private void spawnUnkownCard()
    {
        cardPanel = container.InstantiatePrefab(petCardUnkownPrefab, spawnZone.transform);
    }
}
