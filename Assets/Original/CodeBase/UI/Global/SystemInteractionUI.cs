using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemInteractionUI : MonoBehaviour
{
    [SerializeField] private List<Button> allButonsUIInterection = new List<Button>();

    public void setUnInteract()
    {
        foreach(var button in allButonsUIInterection)
        {
            button.interactable = false;
        }
    }

    public void setInteract()
    {
        foreach (var button in allButonsUIInterection)
        {
            button.interactable = true;
        }
    }
}
