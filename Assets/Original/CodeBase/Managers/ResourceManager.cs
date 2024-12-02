using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ResourceType
{
    Wood = 0,
    Cristals = 1,
    MagicPower = 2,
}
public class ResourceManager : MonoBehaviour, IResourceManager
{
    private float _cristals;
    private float _magicWood;
    private float _magicPower;

    public void AddResource(ResourceType resourceType, float count)
    {
        switch (resourceType)
        {
            case ResourceType.Wood:
                AddMagicWood(count);
                break;
            case ResourceType.Cristals:
                AddCristals(count);
                break;
            case ResourceType.MagicPower:
                AddMagicPower(count);
                break;
        }
    }

    private void AddMagicPower(float count)
    {
        _magicPower += count;
    }

    private void AddCristals(float count)
    {
        _cristals += count;
    }

    private void AddMagicWood(float count)
    {
        _magicWood += count;
    }

    public void RemoveResource(ResourceType resourceType, float count)
    {
        switch (resourceType)
        {
            case ResourceType.Wood:
                if (_magicWood > count)
                {
                    _magicWood -= count;
                }
                break;
            case ResourceType.Cristals:
                if (_cristals > count)
                {
                    _cristals -= count;
                }
                break;
            case ResourceType.MagicPower:
                if (_magicPower > count)
                {
                    _magicPower -= count;
                }
                break;
        }
    }

    public bool CheckEnoughResource(ResourceType resourceType, float requestResources)
    {
        switch (resourceType)
        {
            case ResourceType.Wood:
                if (_magicWood > requestResources)
                {
                    return true;
                }
                break;
            case ResourceType.Cristals:
                if (_cristals > requestResources)
                {
                    return true;
                }
                break;
            case ResourceType.MagicPower:
                if (_magicPower > requestResources)
                {
                    return true;
                }
                break;
        }

        return false;

    }


}
