using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnTimer : MonoBehaviour
{
    [SerializeField]
    private float _timeBeforeDespawn = 5f;

    private float _currentTimer;

    private void Awake()
    {
        _currentTimer = _timeBeforeDespawn;
    }

    private void Update()
    {
        _currentTimer -= Time.deltaTime;

        if (_currentTimer <= 0f)
        {
            Debug.Log("despawn");
            Destroy(gameObject);
        }
    }
}
