using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PetFactoryOnScene : MonoBehaviour
{
    [Inject] private DiContainer diContainer;
    [Inject] private PetManager petManager;

    [SerializeField] private List<GameObject> petsOnScene = new List<GameObject>();
    private List<IPet> petsJoinLine = new List<IPet>();

    [SerializeField] private int MaxPetOnScene = 0;

    private Pet thisIsPet;
    private GameObject currentPet;

    private void Start()
    {
        petManager.UnAvailable += petUnAvailableOnScene;
        petManager.CreatePet += createPet;

        MaxPetOnScene -= 1;
    }

    private void Update()
    {
        CheckMaxPetOnScene();
    }

    private void petUnAvailableOnScene(IPet petObject)
    {
        foreach (var pet in petsOnScene)
        {
            if (petObject.GetName() == pet.transform.name)
            {
                petsOnScene.Remove(pet);
                Destroy(pet);
            }
        }
    }

    private void createPet(IPet pet)
    {

        if (petsOnScene.Count > MaxPetOnScene)
        {
            petsJoinLine.Add(pet);
            foreach (var petik in petsJoinLine)
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

    private void StandartSettings(IPet pet)
    {
        if (currentPet.TryGetComponent<Pet>(out thisIsPet))
        {
            thisIsPet.SetQuality(pet.GetItemQuality());
        }
    }

    private void CheckMaxPetOnScene()
    {
        if (petsOnScene.Count < MaxPetOnScene)
        {
            for (int i = 0; i < petsJoinLine.Count; i++)
            {
                createPet(petsJoinLine[i]);
                petsJoinLine.Remove(petsJoinLine[i]);
                petsOnScene.Add(currentPet);

                if (petsOnScene.Count < MaxPetOnScene)
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
}
