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


    [SerializeField] private List<GameObject> petsOnScene = new List<GameObject>();
    private List<IPet> petsJoinLine = new List<IPet>();

    [SerializeField] private int MaxPetOnScene = 0;

    private void Start()
    {
        MaxPetOnScene -= 1;
    }

    private GameObject currentPet;

    private void Update()
    {
        CheckMaxPetOnScene();
    }

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
                createPet(petObject);

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
        foreach(var pet in petsOnScene)
        {
            if(petObject.GetName() == pet.transform.name)
            {
                AvailablePetsGameObjects.Remove(petObject);
                UnAvailablePetsGameObjects.Add(petObject);
                petsOnScene.Remove(pet);
                Destroy(pet);
            }
        }
    }

    private void CheckMaxPetOnScene()
    {
        if(petsOnScene.Count < MaxPetOnScene)
        {
            for(int i = 0; i < petsJoinLine.Count; i++)
            {
                createPet(petsJoinLine[i]);
                petsJoinLine.Remove(petsJoinLine[i]);
                petsOnScene.Add(currentPet);

                if(petsOnScene.Count < MaxPetOnScene)
                {
                    i = 0;
                }
                else
                {
                    i = petsJoinLine.Count;
                }
            }
        }
    }


    private Pet thisIsPet;

    private void createPet(IPet pet)
    {

        if (petsOnScene.Count > MaxPetOnScene) // !!!!!!!!!!
        {
            petsJoinLine.Add(pet);
            foreach(var petik in petsJoinLine)
            {
                Debug.Log(petik + " +1 in Join Line");
            }
        }
        else
        {
            currentPet = diContainer.InstantiatePrefab(pet.GetPrefab());
            currentPet.name = pet.GetName();
            StandartSettings(pet);
            petsOnScene.Add(currentPet);
        }
    }

    private void initialSetupPet(IPet pet)
    {
        if (pet != null)
        {
            MakeAvailablePet(pet);

            createPet(pet);
        }
        else
        {
            Debug.Log("No creat copy");
        }
    }

    private void StandartSettings(IPet pet)
    {
        if (currentPet.TryGetComponent<Pet>(out thisIsPet))
        {
            thisIsPet.SetQuality(pet.GetItemQuality());
        }
    }
}
