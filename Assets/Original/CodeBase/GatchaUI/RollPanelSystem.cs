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

    public delegate void rollPanelSystem();
    public event rollPanelSystem EventCreatLoadPanel;

    public void instanceManager(IResourceManager managerResourceObject, IGatchaSysteam gatchaSystemObject)
    {
        manager = managerResourceObject;
        gatchaSystem = gatchaSystemObject;
    }

    private void Start()
    {
        buttonTryRoll = gameObject.GetComponentInChildren<Button>();
    }

    public void TryRollPanel()
    {
        EventCreatLoadPanel?.Invoke();
    }


    private void Update()
    {
        if (buttonTryRoll != null)
        {
            //if (manager.CheckEnoughResource(ResourceType.MagicPower, gatchaSystem.GetCostRoll() - 1)) getResourceCount
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

}
