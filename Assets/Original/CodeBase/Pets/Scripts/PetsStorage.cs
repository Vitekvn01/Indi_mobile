using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PetsStorage : MonoBehaviour
{
    [SerializeField] private List<ScriptableObject> copyPets = new List<ScriptableObject>(); // DBG

    [SerializeField] private List <ScriptableObject> OpenPetsEpic = new List<ScriptableObject> (); // DBG
    [SerializeField] private List<ScriptableObject> OpenPetsLegend = new List<ScriptableObject>(); // DBG

    [SerializeField] private List<Pet_4> DefaultPetsEpic = new List<Pet_4>();
    [SerializeField] private List<Pet_5> DefaultPetsLegend = new List<Pet_5>();

    private Pet_4 currentSO_4;
    private Pet_5 currentSO_5;

    public Pet_4 AddPetsEpic(int number)
    {
        if (DefaultPetsEpic[number] != null)
        {
            currentSO_4 = DefaultPetsEpic[number];

            foreach (var copyPet in copyPets)
            {
                if (copyPet == currentSO_4)
                {
                    copyPets.Add(currentSO_4);
                    return AddCopyEpic();
                }
            }

            OpenPetsEpic.Add(currentSO_4);
            copyPets.Add(currentSO_4);

            return currentSO_4;
        }
        return null;
    }

    public Pet_5 AddPetsLegend(int number)
    {
        if (DefaultPetsLegend[number] != null)
        {
            currentSO_5 = DefaultPetsLegend[number];

            foreach(var copyPet in copyPets)
            {
                if(copyPet == currentSO_5)
                {
                    copyPets.Add(currentSO_5);
                    return AddCopyLegend();
                }
            }

            OpenPetsLegend.Add(currentSO_5);
            copyPets.Add(currentSO_5);

            return currentSO_5;
        }

        return null;
    }

    private Pet_5 AddCopyLegend()
    {
        Debug.Log("Copy");

        return null;
    }

    private Pet_4 AddCopyEpic()
    {
        Debug.Log("Copy");

        return null;
    }

    public int CheckCountEpicPet()
    {
        return DefaultPetsEpic.Count;
    }

    public int CheckCountLegendPet()
    {
        return DefaultPetsLegend.Count;
    }
}
