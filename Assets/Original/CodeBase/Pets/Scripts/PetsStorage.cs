using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PetsStorage : MonoBehaviour
{
    //[SerializeField] private List<ScriptableObject> copyPets = new List<ScriptableObject>(); // DBG
    [SerializeField] private List<IPet> copyPets = new List<IPet>(); // DBG

    //[SerializeField] private List <ScriptableObject> OpenPetsEpic = new List<ScriptableObject> (); // DBG
    //[SerializeField] private List <ScriptableObject> OpenPetsLegend = new List<ScriptableObject>(); // DBG

    [SerializeField] private List<Pet_4> DefaultPetsEpic = new List<Pet_4>();
    [SerializeField] private List<Pet_5> DefaultPetsLegend = new List<Pet_5>();

    private List<IPet> OpenPetsEpic = new List<IPet>();
    private List<IPet> OpenPetsLegend = new List<IPet>();

    //private Pet_4 currentSO_4;
    //private Pet_5 currentSO_5;

    private IPet currentSO_4;
    private IPet currentSO_5;

    private int counterCopyPet;

    public int getCountCopy(IPet pet)
    {
        counterCopyPet = 0;

        foreach(var petCopy in copyPets)
        {
            if(pet == petCopy)
            {
                counterCopyPet++;
            }
        }

        return counterCopyPet;
    }

    public IPet AddPetsEpic(int number)
    {
        if (DefaultPetsEpic[number] != null)
        {
            currentSO_4 = DefaultPetsEpic[number];

            foreach (var copyPet in copyPets)
            {
                if (copyPet == currentSO_4)
                {
                    copyPets.Add(currentSO_4);
                    return AddCopy();
                }
            }

            OpenPetsEpic.Add(currentSO_4);
            copyPets.Add(currentSO_4);

            return currentSO_4;
        }
        return null;
    }

    public IPet AddPetsLegend(int number)
    {
        if (DefaultPetsLegend[number] != null)
        {
            currentSO_5 = DefaultPetsLegend[number];

            foreach(var copyPet in copyPets)
            {
                if(copyPet == currentSO_5)
                {
                    copyPets.Add(currentSO_5);
                    return AddCopy();
                }
            }

            OpenPetsLegend.Add(currentSO_5);
            copyPets.Add(currentSO_5);

            return currentSO_5;
        }

        return null;
    }

    private IPet AddCopy()
    {
        Debug.Log("Copy");

        return null;
    }

    public int CheckCountEpicPetDefault()
    {
        return DefaultPetsEpic.Count;
    }

    public int CheckCountLegendPetDefault()
    {
        return DefaultPetsLegend.Count;
    }

    public int CheckCountEpicPetOpen()
    {
        return OpenPetsEpic.Count;
    }

    public int CheckCountLegendPetOpen()
    {
        return OpenPetsLegend.Count;
    }

    public IPet CheckPetNumberEpic(int number)
    {
        return DefaultPetsEpic[number];
    }

    public IPet CheckPetNumberLegend(int number)
    {
        return DefaultPetsLegend[number];
    }

    public IPet getEpicPet(int number)
    {
        return OpenPetsEpic[number];
    }

    public IPet getLegendPet(int number)
    {
        return OpenPetsLegend[number];
    }
}
