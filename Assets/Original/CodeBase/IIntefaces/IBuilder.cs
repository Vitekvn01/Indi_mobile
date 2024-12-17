using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuilder
{
    public event Action OnBuildingEvent;

    public event Action OnClouseBuildingEvent;

    public void SetBuild(GameObject buildPrefab);

    public void Instal();

    public void Cancel();

    public void Rotation();


}
