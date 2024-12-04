using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Zenject;

public class GatchaGlobal : MonoBehaviour, IGatchaSysteam
{
    //[Inject] IResourceManager resourceManager;

    [SerializeField] private float cost = 150;

    [SerializeField] private float maxPercent = 100.0f;

    [SerializeField] private float startPercentLegendary = 1.1f;
    [SerializeField] private float startPercentEpic = 15.0f;
    [SerializeField] private float startPercentRare = 21.0f;

    [SerializeField] private float fractionLegendary = 0.989f;
    [SerializeField] private float fractionEpic = 0.85f;
    [SerializeField] private float fractionRare = 0.79f;

    [SerializeField] private int Garant = 10;
    [SerializeField] private int LegendaryGarant = 90;

    [SerializeField] private float GarantPercentFor4 = 98.9f;

    private float ñurrentPercentLegendary = 1.1f;
    private float currentPercentEpic = 15.0f;
    private float currentPercentRare = 21.0f;

    private int RollNumber;
    private int RollNumberBeforRar;
    private int RollNumberBeforEpic;
    private int RollNumberBeforLegendary;

    private float number;

    private void Start()
    {
        Garant -= 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Roll();
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
        //Debug.Log((RollNumber + 1) + "ROLL NUMBER");
        /*
        if (RollNumber > 0)
        {
            // LEGENDARY
            calculNumber = fractionLegendary;
            for (int i = 0; i < RollNumberBeforLegendary; i++)
            {
                calculNumber = (calculNumber * fractionLegendary);
            }
            ñurrentPercentLegendary = maxPercent - (calculNumber * 100);

            // EPIC
            calculNumber = fractionEpic;

            for (int i = 0; i < RollNumberBeforEpic; i++)
            {
                calculNumber = (calculNumber * fractionEpic);
            }
            currentPercentEpic = maxPercent - (calculNumber * 100);

            // RARE
            calculNumber = fractionRare;

            for (int i = 0; i < RollNumberBeforRar; i++)
            {
                calculNumber = (calculNumber * fractionRare);
            }
            currentPercentRare = maxPercent - (calculNumber * 100);

            Debug.Log(ñurrentPercentLegendary + " " + "Legendary");
            Debug.Log(currentPercentEpic + " " + "Epic");
            Debug.Log(currentPercentRare + " " + "Rare");
        }
        else
        {
            Debug.Log(ñurrentPercentLegendary + " " + "Legendary");
            Debug.Log(currentPercentEpic + " " + "Epic");
            Debug.Log(currentPercentRare + " " + "Rare");
        }

        
        RollNumber++;
        Debug.Log(RollNumber + "ROLL NUMBER");
        */


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
        if (RollNumberBeforEpic != Garant && RollNumberBeforLegendary != LegendaryGarant)
        {
            if (number > currentPercentRare) // common
            {
                // Add common
                Debug.Log("Prize is coomon");

                RollNumberBeforLegendary++;
                RollNumberBeforEpic++;
                RollNumberBeforRar++;

                return;
            }
            if (number > currentPercentEpic) // rare
            {
                // Add rare
                Debug.Log("Prize is rare");
                RollNumberBeforRar = 0;

                RollNumberBeforLegendary++;
                RollNumberBeforEpic++;

                return;
            }
            if (number > ñurrentPercentLegendary) // epic
            {
                // Add epic
                Debug.Log("Prize is epic");

                RollNumberBeforEpic = 0;

                RollNumberBeforLegendary++;
                RollNumberBeforRar++;

                return;
            }
            if (number < ñurrentPercentLegendary)
            {
                // Add Legendary
                Debug.Log("Prize is legendary");

                RollNumberBeforLegendary = 0;
                RollNumberBeforEpic = 0;

                RollNumberBeforRar++;

                return;
            }
        }
        else
        {
            if (RollNumberBeforEpic == Garant)
            {
                RollNumber = 0;

                if (number < 100 - GarantPercentFor4)
                {
                    Debug.Log("Prize is Legendary GARANT");
                    RollNumberBeforLegendary = 0;
                }
                else
                {
                    Debug.Log("Prize is Epic GARANT");
                    RollNumberBeforEpic = 0;
                }
            }

            if (RollNumberBeforLegendary == LegendaryGarant)
            {
                RollNumberBeforLegendary = 0;
                Debug.Log("Prize is Epic");
            }
        }




        /*
        if(RollNumber != Garant && RollNumberBeforLegendary != LegendaryGarant)
        {
            if(number > currentPercentRare) // common
            {
                // Add common
                Debug.Log("Prize is coomon");

                RollNumberBeforLegendary++;
                RollNumberBeforEpic++;
                RollNumberBeforRar++;

                //RollNumber++;
                //Debug.Log((RollNumber + 1) + "ROLL NUMBER");

                return;
            }
            if(number > currentPercentEpic) // rare
            {
                //RollNumber++;
                //Debug.Log((RollNumber + 1) + "ROLL NUMBER");

                // Add rare
                Debug.Log("Prize is rare");

                RollNumberBeforLegendary++;
                RollNumberBeforEpic++;

                RollNumberBeforRar = 0;

                return;
            }
            if(number > ñurrentPercentLegendary) // epic
            {
                //RollNumber++;
                //Debug.Log((RollNumber + 1) + "ROLL NUMBER");

                // Add epic
                Debug.Log("Prize is epic");

                RollNumberBeforEpic = 0;

                RollNumberBeforLegendary++;
                return;
            }
            if( number < ñurrentPercentLegendary)
            {
                //RollNumber++;
               //Debug.Log((RollNumber + 1) + "ROLL NUMBER");


                // Add Legendary
                Debug.Log("Prize is legendary");
                RollNumberBeforLegendary = 0;
                return;
            }
        }
        else
        {
            if(RollNumber == Garant)
            {
                RollNumber = 0;

                if(number < 100 - GarantPercentFor4)
                {
                    Debug.Log("Prize is Legendary");
                    RollNumberBeforLegendary = 0;
                }
                else
                {
                    Debug.Log("Prize is Epic");
                }
            }

            if(RollNumberBeforLegendary == LegendaryGarant)
            {
                RollNumberBeforLegendary = 0;
                Debug.Log("Prize is Epic");
            }
        }
        */

    }
}