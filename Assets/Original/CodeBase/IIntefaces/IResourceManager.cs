using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IResourceManager
{
    public event Action<float> OnCountCrystallEvent;
    public event Action<float> OnCountWoodEvent;
    public event Action<float> OnCountMagicPowerEvent;
    public void AddResource(ResourceType resourceType, float count);

    public void RemoveResource(ResourceType resourceType, float count);

    public bool CheckEnoughResource(ResourceType resourceType, float requestResources);

    public float getResourceCount(ResourceType resourceType);
}
