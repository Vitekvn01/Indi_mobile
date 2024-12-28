using System;
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
    [SerializeField] private float _cristals;
    [SerializeField] private float _magicWood;
    [SerializeField] private float _magicPower;

    public event Action<float> OnCountCrystallEvent;
    public event Action<float> OnCountWoodEvent;
    public event Action<float> OnCountMagicPowerEvent;

    private void Start()
    {
        OnCountCrystallEvent?.Invoke(_cristals);
        OnCountWoodEvent?.Invoke(_magicWood);
        OnCountMagicPowerEvent?.Invoke(_magicPower);
    }
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

    public float getResourceCount(ResourceType resourceType)
    {
        switch (resourceType)
        {
            case ResourceType.Wood: 
                return _magicWood;
            case ResourceType.Cristals:
                return _cristals;
            case ResourceType.MagicPower:
                return _magicPower;
            default:
                return -1;
        }
    }


    private void RemoveMagicPower(float count)
    {
        if (_magicPower >= count)
        {
            _magicPower -= count;
            OnCountMagicPowerEvent?.Invoke(_magicPower);
        }
    }

    private void RemoveCristals(float count)
    {
        if (_cristals > count)
        {
            _cristals -= count;
            OnCountCrystallEvent?.Invoke(_cristals);
        }
    }

    private void RemoveMagicWood(float count)
    {
        if (_magicWood > count)
        {
            _magicWood -= count;
            OnCountWoodEvent?.Invoke(_magicWood);
        }
    }

    private void AddMagicPower(float count)
    {
        _magicPower += count;
        OnCountMagicPowerEvent?.Invoke(_magicPower);
    }

    private void AddCristals(float count)
    {
        _cristals += count;
        OnCountCrystallEvent?.Invoke(_cristals);
        Debug.Log(_cristals + " Crystals");
    }

    private void AddMagicWood(float count)
    {
        _magicWood += count;
        OnCountWoodEvent?.Invoke(_magicWood);
        Debug.Log(_magicWood + " Wood");
    }
}
