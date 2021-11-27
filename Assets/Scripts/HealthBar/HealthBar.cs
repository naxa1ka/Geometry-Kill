public class HealthBar
{
    private readonly IHealth _health;
    private readonly SliderView _sliderView;

    public HealthBar(IHealth health, SliderView sliderView)
    {
        _health = health;
        _sliderView = sliderView;
    }
    
    public void Enable()
    {
        _health.OnHealthChanged += OnHealthChanged;
    }

    private void OnHealthChanged(int currentHealth, int maxHealth)
    {
        _sliderView.UpdateValue(currentHealth, maxHealth);
    }

    public void Disable()
    {
        _health.OnHealthChanged -= OnHealthChanged;
    }
}