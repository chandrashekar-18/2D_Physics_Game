using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject prefab;
    private float _spawnRate = 1f;
    private float _minHeight = -1f;
    private float _maxHeight = 1f;


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
        GameObject coins = Instantiate(prefab, transform.position, Quaternion.identity);
        coins.transform.position += Vector3.up * Random.Range(_minHeight, _maxHeight);
    }
}
