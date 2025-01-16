using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PetCardManager : MonoBehaviour
{
    [SerializeField] private Image imageObject;

    [SerializeField] private GameObject namePanelOject;
    [SerializeField] private GameObject qualityPanelObject;
    [SerializeField] private GameObject typePanelObject;
    [SerializeField] private GameObject countPanelObject;

    private TextMeshProUGUI namePanel;
    private TextMeshProUGUI qualityPanel;
    private TextMeshProUGUI typePanel;
    private TextMeshProUGUI countPanel;

    private void Awake()
    {
        namePanel = namePanelOject.GetComponentInChildren<TextMeshProUGUI>();
        qualityPanel = qualityPanelObject.GetComponentInChildren<TextMeshProUGUI>();
        typePanel = typePanelObject.GetComponentInChildren<TextMeshProUGUI>();
        countPanel = countPanelObject.GetComponentInChildren<TextMeshProUGUI>();
    }


    public void setName(string nameText)
    {
        namePanel.text = nameText;
    }

    public void setQuality(string qualityText)
    {
        qualityPanel.text = qualityText;
    }

    public void setType(string typeText)
    {
        typePanel.text = typeText;
    }

    public void setCount(string countText)
    {
        countPanel.text = countText;
    }
}
