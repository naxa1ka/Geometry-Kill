using UnityEngine;
using Zenject;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private SliderView _sliderView;
    private Player _player;

    [Inject]
    private void Constructor(Player player)
    {
        _player = player;
    }
    
    private void OnEnable()
    {
        _player.OnHealthChanged += OnHealthChanged;
    }

    private void OnHealthChanged(int currentHealth, int maxHealth)
    {
        _sliderView.UpdateValue(currentHealth, maxHealth);
    }

    private void OnDisable()
    {
        _player.OnHealthChanged -= OnHealthChanged;
    }
}