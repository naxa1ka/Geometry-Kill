using DG.Tweening;
using UnityEngine;

public class BallEffects : MonoBehaviour
{
    [SerializeField] private float _scaleAmount = 1.5f;
    [SerializeField] private float _scaleTime = 0.1f;
    [Space(10)] 
    [SerializeField] private SubEmittersParticles _onDieEffects;

    private Color _color;
    
    public void Init(Color color)
    {
        _color = color;
    }

    public void AnimateHit()
    {
        transform
            .DOScale(Vector3.one * _scaleAmount, _scaleTime)
            .OnComplete(() => transform.DORewind());
    }

    public void AnimateDie()
    {
        _onDieEffects = Instantiate(_onDieEffects, transform.position, Quaternion.identity);
        _onDieEffects.ChangeStartColor(_color);
    }
}