using Assets.Original.CodeBase.GatchaSysteam;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Zenject;

public class GatchaGlobal : MonoBehaviour, IGatchaSysteam
{
    [SerializeField] PetsStorage petsStorage; // DBG
    [Inject] IResourceManager resourceManager;

    [Space][Space]

    [SerializeField] private float cost = 150;
    [SerializeField] private float maxPercent = 100.0f;

    [Space][Space]

    [SerializeField] private float startPercentLegendary = 1.1f;
    [SerializeField] private float startPercentEpic = 15.0f;
    [SerializeField] private float startPercentRare = 21.0f;

    [Space][Space]

    [SerializeField] private float fractionLegendary = 0.989f;
    [SerializeField] private float fractionEpic = 0.85f;
    [SerializeField] private float fractionRare = 0.79f;

    [Space][Space]

    [SerializeField] private int EpicGarant = 10;
    [SerializeField] private int LegendaryGarant = 90;
    [SerializeField] private float GarantPercentFor4 = 98.9f;

    [Space][Space]

    [SerializeField] private int AmountPrizeWood;
    [SerializeField] private int AmountPrizeCrystal;
    [SerializeField] private int PrizeCrystalBouns;

    private float ñurrentPercentLegendary = 1.1f;
    private float currentPercentEpic = 15.0f;
    private float currentPercentRare = 21.0f;


    private int RollNumberBeforRar;
    private int RollNumberBeforEpic;
    private int RollNumberBeforLegendary;

    private int currentPetEpic;
    private int currentPetLegend;

    private float number;
    private int calculNumberPet;

    private int PrizeAmount;

    private ItemQuality currentPrize;

    private ResourceType currentResorceTypePrize;

    private void Start()
    {
        EpicGarant -= 1;
        LegendaryGarant -= 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Roll();

            CheckPets();

            AddPrize();
        }
    }

    public void TryRoll()
    {
        /*
        if(resourceManager.CheckEnoughResource(ResourceType.MagicPower, cost))
        {
            Roll();
        }
        */

    }

    private void Roll()
    {
        //resourceManager.RemoveResource(ResourceType.MagicPower,cost);

        number = Random.Range(0.0f, 100.0f);

        Debug.Log(number + " - " + "Number");

        CalculatePercent();

        CalculatePrize();
    }


    private void CalculatePercent()
    {
        float calculNumber;
        
        if (RollNumberBeforLegendary > 0)
        {
            // LEGENDARY
            calculNumber = fractionLegendary;
            for (int i = 0; i < RollNumberBeforLegendary; i++)
            {
                calculNumber = (calculNumber * fractionLegendary);
            }
            ñurrentPercentLegendary = maxPercent - (calculNumber * 100);

            Debug.Log(ñurrentPercentLegendary + " " + "Legendary " + RollNumberBeforLegendary + " " + "Roll Number Legend");
        }
        else
        {
            ñurrentPercentLegendary = startPercentLegendary;
            Debug.Log(ñurrentPercentLegendary + " " + "Legendary " + RollNumberBeforLegendary + " " + "Roll Number Legend");
        }

        if (RollNumberBeforEpic > 0)
        {
            // EPIC
            calculNumber = fractionEpic;

            for (int i = 0; i < RollNumberBeforEpic; i++)
            {
                calculNumber = (calculNumber * fractionEpic);
            }
            currentPercentEpic = maxPercent - (calculNumber * 100);
            Debug.Log(currentPercentEpic + " " + "Epic " + RollNumberBeforEpic + " " + "Roll Number Epic");
        }
        else
        {
            currentPercentEpic = startPercentEpic;
            Debug.Log(currentPercentEpic + " " + "Epic " + RollNumberBeforEpic + " " + "Roll Number Epic");
        }

        if (RollNumberBeforRar > 0)
        {
            // RARE
            calculNumber = fractionRare;

            for (int i = 0; i < RollNumberBeforRar; i++)
            {
                calculNumber = (calculNumber * fractionRare);
            }
            currentPercentRare = maxPercent - (calculNumber * 100);

            Debug.Log(currentPercentRare + " " + "Rare " + RollNumberBeforRar + " " + "Roll Number Rare");
        }
        else
        {
            currentPercentRare = startPercentRare;
            Debug.Log(currentPercentRare + " " + "Rare " + RollNumberBeforRar + " " + "Roll Number Rare");
        }
    }

    private void CalculatePrize()
    {
        if (RollNumberBeforEpic != EpicGarant && RollNumberBeforLegendary != LegendaryGarant)
        {
            if (number > currentPercentRare) // common
            {
                // Add common
                Debug.Log("Prize is coomon");

                RollNumberBeforLegendary++;
                RollNumberBeforEpic++;
                RollNumberBeforRar++;

                currentPrize = ItemQuality.Common;
                CalculCommonBonus();

                return;
            }
            if (number > currentPercentEpic) // rare
            {
                // Add rare
                Debug.Log("Prize is rare");
                RollNumberBeforRar = 0;
                RollNumberBeforLegendary++;
                RollNumberBeforEpic++;

                currentPrize = ItemQuality.Rare;
                CalculRareBonus();

                return;
            }
            if (number > ñurrentPercentLegendary) // epic
            {
                // Add epic
                Debug.Log("Prize is epic");

                RollNumberBeforEpic = 0;

                RollNumberBeforLegendary++;
                RollNumberBeforRar++;

                currentPrize = ItemQuality.Epic;

                return;
            }
            if (number < ñurrentPercentLegendary)
            {
                // Add Legendary
                Debug.Log("Prize is legendary");

                RollNumberBeforLegendary = 0;
                RollNumberBeforEpic = 0;

                RollNumberBeforRar++;

                currentPrize = ItemQuality.Legendary;

                return;
            }
        }
        else
        {
            if (RollNumberBeforEpic == EpicGarant)
            {
                number = Random.Range(0.0f, 100.0f);

                if (number < 100 - GarantPercentFor4)
                {
                    Debug.Log("Prize is Legendary GARANT");
                    RollNumberBeforLegendary = 0;
                    currentPrize = ItemQuality.Legendary;
                }
                else
                {
                    Debug.Log("Prize is Epic GARANT");
                    RollNumberBeforEpic = 0;
                    currentPrize = ItemQuality.Legendary;
                }
            }

            if (RollNumberBeforLegendary == LegendaryGarant)
            {
                RollNumberBeforLegendary = 0;
                Debug.Log("Prize is Legendary");
                currentPrize = ItemQuality.Legendary;
            }
        }
    }

    private void AddPrize()
    {
        switch (currentPrize)
        {
            case ItemQuality.Common:
                resourceManager.AddResource(currentResorceTypePrize, PrizeAmount);
                break;
            case ItemQuality.Rare:
                resourceManager.AddResource(currentResorceTypePrize, PrizeAmount);
                break;
            case ItemQuality.Epic:
                petsStorage.AddPetsEpic(currentPetEpic);
                break;
            case ItemQuality.Legendary:
                petsStorage.AddPetsLegend(currentPetLegend);
                break;
            case ItemQuality.FullPet:
                Debug.Log("All pets unlock!");
                break;
            default:
                break;
        }
    }

    private void CalculCommonBonus()
    {
        number = Random.Range(0.0f, 100.0f);

        if(number < 30)
        {
            PrizeAmount = AmountPrizeCrystal;
            currentResorceTypePrize = ResourceType.Cristals;
        }
        else
        {
            PrizeAmount = AmountPrizeWood;
            currentResorceTypePrize = ResourceType.Wood;
        }
    }

    private void CalculRareBonus()
    {
        PrizeAmount = AmountPrizeCrystal + PrizeCrystalBouns;
        currentResorceTypePrize = ResourceType.Cristals;
    }

    private int CalculateEpic()
    {
        if (petsStorage.CheckCountEpicPet() == 0)
        {
            Debug.Log(currentPetEpic + " EPIC CURRENT");
            return -1;
        }

        calculNumberPet = petsStorage.CheckCountEpicPet();

        number = Random.Range(0, calculNumberPet);

        return (int)number;
    }

    private int CalculateLegend()
    {
        if(petsStorage.CheckCountLegendPet() == 0)
        {
            return -1;
        }

        calculNumberPet = petsStorage.CheckCountLegendPet();

        number = Random.Range(0, calculNumberPet);

        return (int)number;
    }

    private void CheckPets()
    {
        if (currentPrize == ItemQuality.Epic)
        {
            currentPetEpic = CalculateEpic();

            if (currentPetEpic == -1)
            {
                currentPrize = ItemQuality.FullPet;
            }
        }
        else if (currentPrize == ItemQuality.Legendary)
        {
            currentPetLegend = CalculateLegend();

            if (currentPetLegend == -1)
            {
                currentPrize = ItemQuality.FullPet;
            }
        }
    }
}