using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilterPanelStorage : MonoBehaviour
{
    public delegate void Filtres();
    public event Filtres EventSortingAZ;
    public event Filtres EventSortingZA;
    public event Filtres EventSortingQuality;
    public event Filtres EventCloseFilterPanel;

    public void SortingAZButon()
    {
        EventSortingAZ?.Invoke();
    }

    public void SortingZAButton()
    {
        EventSortingZA?.Invoke();
    }

    public void SortingQualityButton()
    {
        EventSortingQuality?.Invoke();
    }

    public void ClosePanel()
    {
        EventCloseFilterPanel?.Invoke();
    }
}
