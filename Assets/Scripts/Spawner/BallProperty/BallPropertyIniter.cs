using UnityEngine;

public class BallPropertyIniter : MonoBehaviour
{
    [SerializeField] private ASpeedIncrease _speedIncrease;
    [SerializeField] private BallProperty _ballProperty;

    public void Init(Ball ball)
    {
        ball.Init(
            _ballProperty.Health,
            _ballProperty.Speed * _speedIncrease.CurrentCoefficientAffect,
            _ballProperty.ScoreOnDie,
            _ballProperty.DamageOnDie,
            _ballProperty.Color,
            _ballProperty.Angle
        );
    }
}