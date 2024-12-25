using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GatchaSystemUI : MonoBehaviour
{
    [SerializeField] private GameObject panelTryRollPrefab;
    [SerializeField] private GameObject panelLoadPrefab;
    [SerializeField] private GameObject panelPrizePrefab;

    [Inject] private IResourceManager manager;
    [Inject] private IGatchaSysteam gatchaSystem;

    [SerializeField] private float LoadPanelTimeActivate = 1;

    [Inject] private DiContainer container;
    
    private GameObject panelTryRoll;
    private GameObject panelLoad;
    private GameObject panelPrize;

    private Button buttonTryRoll;

    private RollPanelSystem rollPanelSystemObject;
    private LoadPanelSystem loadPanelSystemObject;
    private PrizePanelSystem prizePanelSystemObject;

    private float timer;

    private Coroutine currentCorutine;

    private void Start()
    {
        gatchaSystem.AddResource += ChangePrizeText;
    }

    private IEnumerator TimerCoroutine()
    {
        while (timer < LoadPanelTimeActivate)
        {
            Debug.Log(timer);
            timer += Time.deltaTime;
            yield return new WaitForSeconds(0.01f);
        }
        timer = 0;
        stageAfterLoad();
    }

    public void CreatPanelTryRoll()
    {
        if(panelTryRoll == null)
        {
            panelTryRoll = container.InstantiatePrefab(panelTryRollPrefab, gameObject.transform);
            buttonTryRoll = panelTryRoll.GetComponentInChildren<Button>();

            if(panelTryRoll.TryGetComponent<RollPanelSystem>(out rollPanelSystemObject))
            {
                rollPanelSystemObject.InstanceManager(manager, gatchaSystem);
                rollPanelSystemObject.EventCreatLoadPanel += creatLoadPanel;
            }
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

        Destroy(panelTryRoll);

        currentCorutine = StartCoroutine(TimerCoroutine());
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
            prizePanelSystemObject.SetText(resourceTypeSet + " " + resourceCount);
        }
    }

    private ResourceType resourceTypeSet;
    private int resourceCount;

    private void ChangePrizeText(ResourceType type,int count)
    {

        resourceTypeSet = type;
        resourceCount = count;
        /*
        Debug.Log("Change");
        if (panelPrize != null && prizePanelSystemObject != null)
        {
            prizePanelSystemObject.SetText(type + " " + count);
        }
        */
    }

    /*
    private void Update()
    {
        if(panelPrize != null && prizePanelSystemObject != null)
        {

        }
    }
    */
}
