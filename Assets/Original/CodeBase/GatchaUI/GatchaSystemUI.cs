using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GatchaSystemUI : MonoBehaviour
{
    [SerializeField] private GameObject panelRollPrefab;
    [SerializeField] private GameObject panelLoadPrefab;
    [SerializeField] private GameObject panelPrizePrefab;

    [Inject] private IResourceManager manager;
    [Inject] private IGatchaSysteam gatchaSystem;

    [SerializeField] private float LoadPanelTimeActivate = 1;

    [Inject] private DiContainer container;
    
    private GameObject panelRoll;
    private GameObject panelLoad;
    private GameObject panelPrize;

    [SerializeField]private Button buttonTryRoll;

    private RollPanelSystem rollPanelSystemObject;
    private LoadPanelSystem loadPanelSystemObject;
    private PrizePanelSystem prizePanelSystemObject;

    private float timer;

    private Coroutine currentCorutine;

    private ResourceType resourceTypeSet;
    private int resourceCount;

    private string prize;

    private void Start()
    {
        gatchaSystem.AddResource += changePrizeTextResource;
        gatchaSystem.AddPet += changePrizeTextPet;
    }

    private void Update()
    {
        if (panelPrize == null && panelLoad == null && panelRoll == null)
        {
            buttonTryRoll.interactable = true;
        }
        else
        {
            buttonTryRoll.interactable = false;
        }
    }

    private IEnumerator TimerCoroutine()
    {
        while (timer < LoadPanelTimeActivate)
        {
            timer += Time.deltaTime;
            yield return new WaitForSeconds(0.01f);
        }
        timer = 0;
        stageAfterLoad();
    }

    public void CreatPanelTryRoll()
    {
        panelRoll = container.InstantiatePrefab(panelRollPrefab, gameObject.transform);

        if (panelRoll.TryGetComponent<RollPanelSystem>(out rollPanelSystemObject))
        {
            rollPanelSystemObject.InstanceManager(manager, gatchaSystem);
            rollPanelSystemObject.EventCreatLoadPanel += creatLoadPanel;
            rollPanelSystemObject.EventDestroyRollPanel += destroyRollPanel;
        }
    }

    private void creatLoadPanel()
    {
        panelLoad = container.InstantiatePrefab(panelLoadPrefab, gameObject.transform);

        if (panelLoad.TryGetComponent<LoadPanelSystem>(out loadPanelSystemObject))
        {
            loadPanelSystemObject.EventSkipLoad += skipLoadPanel;
        }

        rollPanelSystemObject.EventCreatLoadPanel -= creatLoadPanel;

        currentCorutine = StartCoroutine(TimerCoroutine());
    }

    private void destroyRollPanel()
    {
        Destroy(panelRoll);
    }

    private void skipLoadPanel()
    {
        StopCoroutine(currentCorutine);
        timer = 0;

        stageAfterLoad();
    }

    private void destroyLoadPanel()
    {
        if (panelLoad != null)
        {
            loadPanelSystemObject.EventSkipLoad -= skipLoadPanel;
            Destroy(panelLoad);
        }
    }

    private void stageAfterLoad()
    {
        destroyLoadPanel();
        gatchaSystem.TryRoll();
        createPrizePanelSystem();
    }

    private void createPrizePanelSystem()
    {
        panelPrize = container.InstantiatePrefab(panelPrizePrefab, gameObject.transform);

        if (panelPrize.TryGetComponent<PrizePanelSystem>(out prizePanelSystemObject))
        {
            prizePanelSystemObject.InstanceManager(gatchaSystem);
            prizePanelSystemObject.SetText(prize);
            prizePanelSystemObject.EventPrizePanelDestroy += destroyPrizePanel;
        }
    }

    private void destroyPrizePanel()
    {
        if(panelPrize != null)
        {
            Destroy(panelPrize);
        }
    }

    private void changePrizeTextResource(ResourceType type,int count)
    {
        resourceTypeSet = type;
        resourceCount = count;

        prize = resourceTypeSet + " " + resourceCount;
    }

    private void changePrizeTextPet(IPet pet)
    {
        prize = pet.GetName();
    }
}
