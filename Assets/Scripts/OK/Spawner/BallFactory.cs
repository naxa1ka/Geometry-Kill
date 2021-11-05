using System.Collections.Generic;
using UnityEngine;

public class BallFactory : MonoBehaviour
{
    [SerializeField] private List<Ball> _ballsPrefab;

    public Ball Spawn()
    {
        return Instantiate(_ballsPrefab.RandomItem());
    }

    public Ball Spawn(Vector3 position, Quaternion quaternion)
    {
        return Instantiate(_ballsPrefab.RandomItem(), position, quaternion);
    }

    public Ball Spawn(Vector3 position, Quaternion quaternion, Transform container)
    {
        return Instantiate(_ballsPrefab.RandomItem(), position, quaternion, container);
    }
}