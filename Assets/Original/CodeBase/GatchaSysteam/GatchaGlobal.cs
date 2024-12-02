using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GatchaGlobal : MonoBehaviour, IGatchaSysteam
{
    [Inject] IResourceManager resourceManager;

    private int RollNumberEpic;
    private int RollNumberLegendary;

    private float maxPercent;
    private float startPercent;

    private float ñurrentPercentLegendary;
    private float fractionLegendary;

    private float currentPercentEpic;
    private float fractionEpic;

    private float CurrentPercentRare;
    private float fractionRare;

    public void TryRoll()
    {
        throw new System.NotImplementedException();
    }
}
