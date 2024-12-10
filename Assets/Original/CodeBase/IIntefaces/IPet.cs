using Assets.Original.CodeBase.GatchaSysteam;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPet
{
    public ItemQuality GetItemQuality();

    public string GetName();

    public GameObject GetPrefab();

}
