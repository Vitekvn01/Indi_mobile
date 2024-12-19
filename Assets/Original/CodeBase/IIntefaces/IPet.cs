using Assets.Original.CodeBase.GatchaSysteam;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPet
{
    public ItemQuality GetItemQuality();

    public GameObject GetPrefab();

    public string GetName();

    public string GetPetType();

}
