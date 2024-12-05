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

    public void RemoveResource(ResourceType resourceType, float count)
    {
        switch (resourceType)
        {
            case ResourceType.Wood:
                RemoveMagicWood(count);
                break;
            case ResourceType.Cristals:
                RemoveCristals(count);
                break;
            case ResourceType.MagicPower:
                RemoveMagicPower(count);
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


    private void RemoveMagicPower(float count)
    {
        if (_magicPower > count)
        {
            _magicPower -= count;
        }
    }

    private void RemoveCristals(float count)
    {
        if (_cristals > count)
        {
            _cristals -= count;
        }
    }

    private void RemoveMagicWood(float count)
    {
        if (_magicWood > count)
        {
            _magicWood -= count;
        }
    }

    private void AddMagicPower(float count)
    {
        _magicPower += count;
    }

    private void AddCristals(float count)
    {
        _cristals += count;
        Debug.Log(_cristals + " Crystals");
    }

    private void AddMagicWood(float count)
    {
        _magicWood += count;
        Debug.Log(_magicWood + " Wood");
    }




}
