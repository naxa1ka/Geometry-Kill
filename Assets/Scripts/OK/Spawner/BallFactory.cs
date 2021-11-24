using System.Collections.Generic;
using UnityEngine;

public class BallFactory : MonoBehaviour
{
    [SerializeField] private List<Ball> _ballsPrefab;
    [SerializeField] private BallPropertyIniter _ballPropertyIniter;

    public Ball Spawn()
    {
        var ball = Instantiate(_ballsPrefab.RandomItem());
        _ballPropertyIniter.Init(ball);
        
        return ball;
    }

    public Ball Spawn(Vector3 position, Quaternion quaternion)
    {
        var ball = Instantiate(_ballsPrefab.RandomItem(), position, quaternion);
        _ballPropertyIniter.Init(ball);

        return ball;
    }

    public Ball Spawn(Vector3 position, Quaternion quaternion, Transform container)
    {
        var ball = Instantiate(_ballsPrefab.RandomItem(), position, quaternion, container);
        _ballPropertyIniter.Init(ball);

        return ball;
    }
}