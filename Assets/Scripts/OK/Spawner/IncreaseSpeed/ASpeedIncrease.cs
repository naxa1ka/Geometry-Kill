using UnityEngine;

public abstract class ASpeedIncrease : MonoBehaviour
{
    [SerializeField] private float _timeBetweenIncrease;
    private float _elapsedTime;
    
    public float CurrentCoefficientAffect { get; protected set; } = 1f;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime > _timeBetweenIncrease)
        {
            IncreaseSpeed();
            _elapsedTime = 0f;
        }
    }

    protected abstract void IncreaseSpeed();
}