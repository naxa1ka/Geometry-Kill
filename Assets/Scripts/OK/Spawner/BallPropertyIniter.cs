using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MinMax
{
    [SerializeField] private float _min;
    [SerializeField] private float _max;

    public float Min => _min;
    public float Max => _max;

    public float Random()
    {
        var normalizedRandomValue = UnityEngine.Random.Range(0f, 1f);
        return Mathf.Lerp(_min, _max, normalizedRandomValue);
    }
}

public class BallPropertyIniter : MonoBehaviour
{
    [SerializeField] private MonoBehaviour _speedIncrease;
    [Space(10)]
    [SerializeField] private MinMax _health;
    [SerializeField] private MinMax _angle;
    [SerializeField] private MinMax _speed;
    [SerializeField] private MinMax _scoreOnDie;
    [SerializeField] private MinMax _damageOnDie;
    [SerializeField] private List<Color> _colors;

    private ASpeedIncrease SpeedIncrease => (ASpeedIncrease) _speedIncrease;

    private void OnValidate()
    {
        if (_speedIncrease is ASpeedIncrease) return;

        Debug.LogError($"{_speedIncrease.name} must be implement {nameof(ASpeedIncrease)}");
        _speedIncrease = null;
    }

    public void Init(Ball ball)
    {
        ball.Init(
            _health.Random(),
            _speed.Random() * SpeedIncrease.CurrentCoefficientAffect,
            Mathf.CeilToInt(_scoreOnDie.Random()),
            Mathf.CeilToInt(_damageOnDie.Random()),
            _colors.RandomItem(),
            new Vector3(0, 0, _angle.Random())
            );
    }
}