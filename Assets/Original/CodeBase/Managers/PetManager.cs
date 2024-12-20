using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting;
using Zenject;

public class PetManager : MonoBehaviour
{
    [Inject] private PetsStorage petsStorage;
    [Inject] private DiContainer diContainer;

    [SerializeField] private List<IPet> AvailablePetsGameObjects = new List<IPet>();
    [SerializeField] private List<IPet> UnAvailablePetsGameObjects = new List<IPet>();

    public delegate void Manager(IPet pet);
    public event Manager UnAvailable;
    public event Manager CreatePet;

    public void AddPetsEpic(int number)
    {
        initialSetupPet(petsStorage.AddPetsEpic(number));
    }

    public void AddPetsLegend(int number)
    {
        initialSetupPet(petsStorage.AddPetsLegend(number));
    }

    public int CheckCountEpicPet()
    {
        return petsStorage.CheckCountEpicPet();
    }

    public int CheckCountLegendPet()
    {
        return petsStorage.CheckCountLegendPet();
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
