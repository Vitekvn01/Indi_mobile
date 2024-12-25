using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PrizePanelSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textPrizeObject;

    private IGatchaSysteam gatchaGlobal;

    private Text textPrize;

    public void InstanceManager(IGatchaSysteam gatchaSystem)
    {
        gatchaGlobal = gatchaSystem;
    }


    public void SetText(string text)
    {
        textPrizeObject.text = text;
    }
}
