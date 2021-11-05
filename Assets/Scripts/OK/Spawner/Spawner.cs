using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private BallPropertyIniter _ballPropertyIniter;
    [SerializeField] private List<Transform> _spawnPositions;
    [SerializeField] private BallFactory _ballFactory;
    [Space(10)]
    [SerializeField] private float _delayBeforeSpawn;

    private float _elapsedTime;

    public event Action<Ball> OnBallSpawned;

    private void Update()
    {
        if (_elapsedTime > _delayBeforeSpawn)
        {
            Spawn();
            _elapsedTime = 0f;
        }

        _elapsedTime += Time.deltaTime;
    }

    private void Spawn()
    {
        var ball = _ballFactory.Spawn(_spawnPositions.RandomItem().position, Quaternion.identity);
        _ballPropertyIniter.Init(ball);
        
        OnBallSpawned?.Invoke(ball);
    }
}