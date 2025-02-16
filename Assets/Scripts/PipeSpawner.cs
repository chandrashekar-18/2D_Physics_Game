using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject _prefab;
    private float _spawnRate = 1f;
    private float _minHeight = -1f;
    private float _maxHeight = 2f;


    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), _spawnRate, _spawnRate);

    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject pipes = Instantiate(_prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(_minHeight, _maxHeight);
    }
}
