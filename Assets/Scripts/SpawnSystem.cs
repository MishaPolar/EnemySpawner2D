﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] private float _spawnTime = 1f;
    [SerializeField] private GameObject _spawnObject;

    private float _currentTime = 0;
    private int _currentSpawnPoint = 0;
    private List<GameObject> _spawnPoints = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _spawnPoints.Add(transform.GetChild(i).gameObject);
        }
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= _spawnTime)
        {
            _currentTime -= _spawnTime;
            _spawnPoints[_currentSpawnPoint].GetComponent<Spawner>().Spawn(_spawnObject);

            if (_currentSpawnPoint == transform.childCount - 1)
            {
                _currentSpawnPoint = 0;
            }
            else
            {
                _currentSpawnPoint++;
            }
        }
    }

}