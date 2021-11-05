using UnityEngine;

public class SpeedIncreasePerTimeCurve : ASpeedIncrease
{
    [SerializeField] private AnimationCurve _animationCurve;
    [Space(10)]
    [SerializeField] private float _coefficientMultiplyCurve;
    
    private int _currentKey;

    protected override void IncreaseSpeed()
    {
        var curveValue = _animationCurve.keys[_currentKey].value;
        CurrentCoefficientAffect += curveValue * _coefficientMultiplyCurve;
        
        NextKey();
    }

    private void NextKey()
    {
        _currentKey++;
        if (_currentKey == _animationCurve.keys.Length - 1)
        {
            _currentKey = 0;
        }
    }
}