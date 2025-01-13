using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuilder
{
    public event Action OnStartBuildingEvent;
    public event Action OnClouseBuildingEvent;

    public event Action OnCompleteBuildingEvent;
    public event Action OnCancelBuildingEvent;

    public void CreateBuild(GameObject buildPrefab);

    public void SetCurrentBuild(GameObject build);
    public void Instal();

    public void Cancel();

    public void Rotation();


}
