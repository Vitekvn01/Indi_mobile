using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainStoragePanelUI : MonoBehaviour
{
    [SerializeField] private GameObject spawnZone;

    [SerializeField] private GameObject petCardPrefab;
    [SerializeField] private GameObject petCardUnkownPrefab;

    [SerializeField] private GameObject filterButtonPrefab;

    [SerializeField] private GameObject filtresPanelPrefab;
    [SerializeField] private GameObject viewPortTransform;

    [Inject] private PetManager petManager;
    [Inject] DiContainer container;

    private GameObject cardPanel;
    private PetCardManager cardManager;
    private GameObject petCardObject;

    private GameObject filterButtonObject;
    private GameObject filtresPanelObject;

    private Button filterButton;
    private FilterPanelStorage filter;

    public delegate void StoragePanelUI();
    public event StoragePanelUI EventCloseStoragePanel;

    private int countAllPets;
    private int counterPets;

    private SortingType sortingType = SortingType.Quality;

    private List<GameObject> allCards = new List<GameObject>();
    private List<GameObject> unkownAllCards = new List<GameObject>();

    private void Start()
    {
        creatFilterButton();
    }

    public void LoadPanel()
    {
        petManager.sortingPets(sortingType);
        
        for(int i = 0; i < petManager.getCountCopy();i++)
        {
            petCardObject = spawnCardInSpawnZone();
            cardManager = petCardObject.GetComponent<PetCardManager>();
            cardManager.setName(petManager.getSortingStorage(i).GetName());
            cardManager.setQuality(petManager.getSortingStorage(i).GetItemQuality().ToString());
            cardManager.setType(petManager.getSortingStorage(i).GetPetType());
            cardManager.setCount(petManager.GetCopyCountPet(petManager.getSortingStorage(i)).ToString());

            allCards.Add(petCardObject); 

            counterPets++;

            cardManager = null;
        }

        countAllPets = petManager.CheckCountEpicPetDefault() + petManager.CheckCountLegendPetDefault() - counterPets;

        for (int i = 0; i < countAllPets; i++)
        {
            spawnUnkownCard();
        }
    }

    
    public void sortingAZ()
    {
        sortingType = SortingType.AZ;

        for (int i = 0; i < allCards.Count; i++)
        {
            Destroy(allCards[i]);
        }

        for (int i = 0; i < unkownAllCards.Count; i++)
        {
            Destroy(unkownAllCards[i]);
        }

        counterPets = 0;

        LoadPanel();
    }

    public void sortingZA()
    {
        sortingType = SortingType.ZA;

        for (int i = 0; i < allCards.Count; i++)
        {
            Destroy(allCards[i]);
        }

        for (int i = 0; i < unkownAllCards.Count; i++)
        {
            Destroy(unkownAllCards[i]);
        }

        counterPets = 0;

        LoadPanel();
    }

    public void sortingQuality()
    {
        sortingType = SortingType.Quality;

        for (int i = 0; i < allCards.Count; i++)
        {
            Destroy(allCards[i]);
        }

        for (int i = 0; i < unkownAllCards.Count; i++)
        {
            Destroy(unkownAllCards[i]);
        }

        counterPets = 0;

        LoadPanel();
    }
    

    public void OpenFilterPanel()
    {
        filtresPanelObject = container.InstantiatePrefab(filtresPanelPrefab, viewPortTransform.gameObject.transform);

        if(filtresPanelObject.TryGetComponent<FilterPanelStorage>(out filter))
        {
            filter.EventSortingAZ += sortingAZ;
            filter.EventSortingZA += sortingZA;
            filter.EventSortingQuality += sortingQuality;
            filter.EventCloseFilterPanel += closeSortingPanel;
        }
    }
    public void ClosePanel()
    {
        closeSortingPanel();

        EventCloseStoragePanel?.Invoke();
    }

    private void creatFilterPanel()
    {
        filterButton.onClick.RemoveListener(OpenFilterPanel);
        OpenFilterPanel();
        Destroy(filterButtonObject);
    }

    private void creatFilterButton()
    {
        filterButtonObject = container.InstantiatePrefab(filterButtonPrefab, viewPortTransform.gameObject.transform);
        if (filterButtonObject.TryGetComponent<Button>(out filterButton))
        {
            filterButton.onClick.AddListener(creatFilterPanel);
        }
    }

    private void closeSortingPanel()
    {
        if (filter != null)
        {
            filter.EventSortingAZ -= sortingAZ;
            filter.EventSortingZA -= sortingZA;
            filter.EventSortingQuality -= sortingQuality;
            filter.EventCloseFilterPanel -= closeSortingPanel;
        }

        Destroy(filtresPanelObject);
        creatFilterButton();
    }

    private GameObject spawnCardInSpawnZone()
    {
        cardPanel = container.InstantiatePrefab(petCardPrefab, spawnZone.transform);

        return cardPanel;
    }

    private void spawnUnkownCard()
    {
       unkownAllCards.Add(cardPanel = container.InstantiatePrefab(petCardUnkownPrefab, spawnZone.transform));
    }
}
