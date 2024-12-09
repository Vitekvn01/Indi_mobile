using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PetManager : MonoBehaviour
{
    [Inject] PetsStorage petsStorage;

    public void AddPetsEpic(int number)
    {
        petsStorage.AddPetsEpic(number);
    }

    public void AddPetsEpic(string name)
    {
        petsStorage.AddPetsEpic(name);
    }

    public void AddPetsLegend(int number)
    {
        petsStorage.AddPetsLegend(number);
    }

    public void AddPetsLegend(string name)
    {
        petsStorage.AddPetsLegend(name);
    }

    public int CheckCountEpicPet()
    {
        return petsStorage.CheckCountEpicPet();
    }

    public int CheckCountLegendPet()
    {
        return petsStorage.CheckCountLegendPet();
    }

}
