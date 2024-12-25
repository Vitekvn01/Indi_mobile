using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public interface IGatchaSysteam
{
    public void TryRoll();

    public float GetCostRoll();

    public delegate void EventAddResource(ResourceType type, int count);
    public event EventAddResource AddResource;

    public delegate void EventAddPet(IPet pet);
    public event EventAddPet AddPet;

}
