using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using static PetManager;

public class RollPanelSystem : MonoBehaviour
{
    private IResourceManager manager;
    private IGatchaSysteam gatchaSystem;

    private Button buttonTryRoll;

    public delegate void RollPanel();
    public event RollPanel EventCreatLoadPanel;
    public event RollPanel EventDestroyRollPanel;

    private void Start()
    {
        buttonTryRoll = gameObject.GetComponentInChildren<Button>();
    }

    private void Update()
    {
        if (buttonTryRoll != null)
        {
            if (manager.getResourceCount(ResourceType.MagicPower) >= gatchaSystem.GetCostRoll())
            {
                buttonTryRoll.interactable = true;
            }
            else
            {
                buttonTryRoll.interactable = false;
            }
        }
    }

    public void InstanceManager(IResourceManager managerResourceObject, IGatchaSysteam gatchaSystemObject)
    {
        manager = managerResourceObject;
        gatchaSystem = gatchaSystemObject;
    }

    public void TryRollPanel()
    {
        EventCreatLoadPanel?.Invoke();
        DestroyPanel();
    }

    public void DestroyPanel()
    {
        EventDestroyRollPanel?.Invoke();
    }
}
