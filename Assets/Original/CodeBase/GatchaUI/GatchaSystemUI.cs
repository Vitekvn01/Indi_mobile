using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GatchaSystemUI : MonoBehaviour
{
    [SerializeField] private GameObject panelTryRollPrefab;
    [SerializeField] private GameObject panelLoadPrefab;

    [Inject] private IResourceManager manager;
    [Inject] private IGatchaSysteam gatchaSystem;

    [SerializeField] private float LoadPanelTimeActivate = 1;

    [Inject] private DiContainer container;
    
    private GameObject panelTryRoll;
    private GameObject panelLoad;

    private Button buttonTryRoll;

    private RollPanelSystem rollPanelSystemObject;
    private LoadPanelSystem loadPanelSystemObject;

    private float timer;

    private Coroutine currentCorutine;

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
                rollPanelSystemObject.instanceManager(manager, gatchaSystem);
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
    }

}
