using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CardSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnZone;
    
    [Inject] DiContainer container;

    private GameObject cardPanel;
    public GameObject spawnCardInSpawnZone(GameObject cardPrefab)
    {
         cardPanel = container.InstantiatePrefab(cardPrefab, spawnZone.transform);

        return cardPanel;
    }
}
