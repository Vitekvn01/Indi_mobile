using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class PetManager : MonoBehaviour
{
    [Inject] private PetsStorage petsStorage;
    [Inject] private DiContainer diContainer;

    [SerializeField] private List<GameObject> AvailablePetsGameObjects = new List<GameObject>();
    [SerializeField] private List<GameObject> UnAvailablePetsGameObjects = new List<GameObject>();


    private GameObject currentPet;

    public void AddPetsEpic(int number)
    {
        CreatPet(petsStorage.AddPetsEpic(number));
    }

    public void AddPetsLegend(int number)
    {
        CreatPet(petsStorage.AddPetsLegend(number));
    }

    public int CheckCountEpicPet()
    {
        return petsStorage.CheckCountEpicPet();
    }

    public int CheckCountLegendPet()
    {
        return petsStorage.CheckCountLegendPet();
    }

    private void MakeAvailablePet(GameObject petObject)
    {
        foreach(var pet in UnAvailablePetsGameObjects)
        {
            if(pet == petObject)
            {
                UnAvailablePetsGameObjects.Remove(petObject);
            }
        }

        AvailablePetsGameObjects.Add(petObject);
    }

    private void MakeUnAvailablePet(GameObject petObject)
    {
        foreach (var pet in AvailablePetsGameObjects)
        {
            if (pet == petObject)
            {
                AvailablePetsGameObjects.Remove(petObject);
                UnAvailablePetsGameObjects.Add(petObject);
            }
        }
    }

    private void CreatPet(Pet_4 pet)
    {
        if(pet != null)
        {
            currentPet = diContainer.InstantiatePrefab(pet.GetPrefab());
            currentPet.name = pet.GetName();

            MakeAvailablePet(currentPet);
        }
    }

    private void CreatPet(Pet_5 pet)
    {
        if (pet != null)
        {
            currentPet = diContainer.InstantiatePrefab(pet.GetPrefab());
            currentPet.name = pet.GetName();

            MakeAvailablePet(currentPet);
        }
    }

    private void DestroyPet()
    {

    }

}
