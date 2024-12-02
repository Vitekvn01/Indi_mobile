using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IResourceManager
{
    public void AddResource(ResourceType resourceType, float count);

    public void RemoveResource(ResourceType resourceType, float count);

    public bool CheckEnoughResource(ResourceType resourceType, float requestResources);
}
