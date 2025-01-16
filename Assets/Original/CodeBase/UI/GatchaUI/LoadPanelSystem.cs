using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPanelSystem : MonoBehaviour
{
    public delegate void LoadSystem();
    public event LoadSystem EventSkipLoad;

    public void skipLoadPanel()
    {
        EventSkipLoad?.Invoke();
    }
}
