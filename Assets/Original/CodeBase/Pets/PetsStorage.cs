using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PetsStorage : MonoBehaviour
{
    [SerializeField] private List <ScriptableObject> OpenPetsEpic = new List<ScriptableObject> (); // DBG
    [SerializeField] private List<ScriptableObject> OpenPetsLegend = new List<ScriptableObject>(); // DBG

    [SerializeField] private List<Pet_4> UnOpenPetsEpic = new List<Pet_4>();
    [SerializeField] private List<Pet_5> UnOpenPetsLegend = new List<Pet_5>();

    private Pet_4 currentSO_4;
    private Pet_5 currentSO_5;

    public Pet_4 AddPetsEpic(int number)
    {
        if (UnOpenPetsEpic[number] != null)
        {
            currentSO_4 = null;

            OpenPetsEpic.Add(currentSO_4 = UnOpenPetsEpic[number]);
            UnOpenPetsEpic.Remove(UnOpenPetsEpic[number]);

            return currentSO_4;
        }

        return null;
    }

    public Pet_5 AddPetsLegend(int number)
    {
        if (UnOpenPetsLegend[number] != null)
        {
            currentSO_5 = null;

            OpenPetsLegend.Add(currentSO_5 = UnOpenPetsLegend[number]);
            UnOpenPetsLegend.Remove(UnOpenPetsLegend[number]);

            return currentSO_5;
        }

        return null;
    }

    public int CheckCountEpicPet()
    {
        return UnOpenPetsEpic.Count;
    }

    public int CheckCountLegendPet()
    {
        return UnOpenPetsLegend.Count;
    }
}
