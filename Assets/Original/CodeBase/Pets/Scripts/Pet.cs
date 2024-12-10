using Assets.Original.CodeBase.GatchaSysteam;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Pet : MonoBehaviour
{
    [SerializeField] private ItemQuality itemQuality;

    public void SetQuality(ItemQuality quality)
    {
        itemQuality = quality;
    }

    private void Update()
    {
        //transform.position = Vector3.MoveTowards(gameObject,)
    }
}
