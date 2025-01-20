using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting;
using Zenject;

public enum SortingType
{
    Quality,
    AZ,
    ZA,
};


public class PetManager : MonoBehaviour
{
    [Inject] private PetsStorage petsStorage;
    [Inject] private DiContainer diContainer;

    [SerializeField] private List<IPet> AvailablePetsGameObjects = new List<IPet>();
    [SerializeField] private List<IPet> UnAvailablePetsGameObjects = new List<IPet>();

    public delegate void Manager(IPet pet);
    public event Manager UnAvailable;
    public event Manager CreatePet;

    private IPet currentPett;

    public IPet AddPetsEpic(int number)
    {
        currentPett = petsStorage.AddPetsEpic(number);
        initialSetupPet(currentPett);

        if(currentPett == null)
        {
            currentPett = petsStorage.CheckPetNumberEpic(number);
        }

        return currentPett;
    }

    public IPet AddPetsLegend(int number)
    {
        currentPett = petsStorage.AddPetsLegend(number);
        initialSetupPet(currentPett);

        if (currentPett == null)
        {
            currentPett = petsStorage.CheckPetNumberLegend(number);
        }

        return currentPett;
    }

    public IPet getSortingStorage(int number)
    {
        return petsStorage.getSorting(number);
    }

    public int getCountCopy()
    {
        return petsStorage.getCopyCount();
    }

    public int CheckCountEpicPetOpen()
    {
        return petsStorage.CheckCountEpicPetOpen();
    }

    public int CheckCountLegendPetOpen()
    {
        return petsStorage.CheckCountLegendPetOpen();
    }


    public int CheckCountEpicPetDefault()
    {
        return petsStorage.CheckCountEpicPetDefault();
    }

    public int CheckCountLegendPetDefault()
    {
        return petsStorage.CheckCountLegendPetDefault();
    }

    public int GetCopyCountPet(IPet pet)
    {
        return petsStorage.getCountCopy(pet);
    }

    public void sortingPets(SortingType type)
    {
        petsStorage.sortingForUI(type);
    }

    private void MakeAvailablePet(IPet petObject)
    {
        foreach(var pet in UnAvailablePetsGameObjects)
        {
            if(pet.GetName() == petObject.GetName())
            {
                CreatePet?.Invoke(petObject);

                UnAvailablePetsGameObjects.Remove(petObject);
            }
        }

        AvailablePetsGameObjects.Add(petObject);

        foreach (var petik in AvailablePetsGameObjects)
        {
            Debug.Log(petik + " +1 AvailablePetsGameObjects");
        }
    }

    private void MakeUnAvailablePet(IPet petObject)
    {
        AvailablePetsGameObjects.Remove(petObject);
        UnAvailablePetsGameObjects.Add(petObject);

        UnAvailable?.Invoke(petObject);
    }

    private void initialSetupPet(IPet pet)
    {
        if (pet != null)
        {
            MakeAvailablePet(pet);

            CreatePet?.Invoke(pet);
        }
        else
        {
            Debug.Log("No creat copy");
        }
    }
}
