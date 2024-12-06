using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetsStorage : MonoBehaviour
{
    [SerializeField] private List <ScriptableObject> OpenPetsEpic = new List<ScriptableObject> (); // DBG
    [SerializeField] private List<ScriptableObject> OpenPetsLegend = new List<ScriptableObject>(); // DBG

    [SerializeField] private List<ScriptableObject> UnOpenPetsEpic = new List<ScriptableObject>();
    [SerializeField] private List<ScriptableObject> UnOpenPetsLegend = new List<ScriptableObject>();

    public void AddPetsEpic(int number)
    {
        if (UnOpenPetsEpic[number] != null)
        {
            OpenPetsEpic.Add(UnOpenPetsEpic[number]);
            UnOpenPetsEpic.Remove(UnOpenPetsEpic[number]);
        }
    }

    public void AddPetsLegend(int number)
    {
        if (UnOpenPetsLegend[number] != null)
        {
            OpenPetsLegend.Add(UnOpenPetsLegend[number]);
            UnOpenPetsLegend.Remove(UnOpenPetsLegend[number]);
        }
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
