using UnityEngine;

public class HealthBarSetup : MonoBehaviour
{
    [SerializeField] private MonoBehaviour _health;
    [SerializeField] private SliderView _sliderView;

    private IHealth Health => (IHealth)_health;

    private HealthBar _healthBar;

    private void OnValidate()
    {
        if (_health is IHealth) return;

        Debug.LogError($"{_health.name} must be implement {nameof(IHealth)}");
        _health = null;
    }

    private void OnEnable()
    {
        _healthBar.Enable();
    }

    private void Awake()
    {
        _healthBar = new HealthBar(Health, _sliderView);
    }

    private void OnDisable()
    {
        _healthBar.Disable();
    }
}