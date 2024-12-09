using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public void AddPetsEpic(string name)
    {
        for (int i = 0; i < UnOpenPetsEpic.Count; i++)
        {
            if(UnOpenPetsEpic[i].name == name)
            {
                OpenPetsEpic.Add(UnOpenPetsEpic[i]);
                UnOpenPetsEpic.Remove(UnOpenPetsEpic[i]);
            }
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

    public void AddPetsLegend(string name)
    {
        for (int i = 0; i < UnOpenPetsLegend.Count; i++)
        {
            if (UnOpenPetsLegend[i].name == name)
            {
                UnOpenPetsLegend.Add(UnOpenPetsLegend[i]);
                UnOpenPetsLegend.Remove(UnOpenPetsLegend[i]);
            }
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
