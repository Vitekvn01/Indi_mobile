using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowView : MonoBehaviour
{
    protected virtual void ShowPanel()
    {
        gameObject.SetActive(true);
    }

    protected virtual void HidePanel()
    {
        gameObject.SetActive(false);
    }
}
