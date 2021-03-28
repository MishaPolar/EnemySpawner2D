using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] private float _spawnTime = 1f;
    [SerializeField] private GameObject _spawnObject;

    private float _currentTime = 0;
    private int _currentSpawnPoint = 0;
    private List<Spawner> _spawners = new List<Spawner>();

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _spawners.Add(transform.GetChild(i).gameObject.GetComponent<Spawner>());
        }
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= _spawnTime)
        {
            _currentTime -= _spawnTime;
            _spawners[_currentSpawnPoint].Spawn(_spawnObject);

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