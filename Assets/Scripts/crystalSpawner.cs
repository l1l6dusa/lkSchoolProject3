using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crystalSpawner : MonoBehaviour
{
    private CrystalSpawnPoint[] _crystalSpawnPoints;

    [SerializeField]
    private Crystal _crystalPrefab;

    private void Awake()
    {
        _crystalSpawnPoints = transform.GetComponentsInChildren<CrystalSpawnPoint>();
    }

    private void Start()
    {
        foreach (var point in _crystalSpawnPoints)
        {
            Instantiate(_crystalPrefab, point.transform.position, Quaternion.identity, point.transform);
        }
    }
}
