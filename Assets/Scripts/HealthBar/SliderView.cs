using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderView : MonoBehaviour
{
    [SerializeField] private float _animationTime = 0.25f;
    
    private Slider _slider;
    
    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    public void UpdateValue(int currentValue, int maxValue)
    {
        var normalizedValue = (float) currentValue / maxValue;
        _slider.DOValue(normalizedValue, _animationTime);
    }
}