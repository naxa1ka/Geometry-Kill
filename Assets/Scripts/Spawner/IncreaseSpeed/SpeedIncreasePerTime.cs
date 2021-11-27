using UnityEngine;

public class SpeedIncreasePerTime : ASpeedIncrease
{
    [SerializeField] private float _coefficientAffect;

    protected override void IncreaseSpeed()
    {
        CurrentCoefficientAffect += _coefficientAffect;
    }
}