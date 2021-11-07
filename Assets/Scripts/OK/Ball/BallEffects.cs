using DG.Tweening;
using UnityEngine;

public class BallEffects : MonoBehaviour
{
    [Header("AnimationSettings")] 
    [SerializeField] private float _scaleAmount = 1.5f;
    [SerializeField] private float _scaleTime = 0.1f;
    [Space(10)] 
    [SerializeField] private SubEmittersParticles _onDieEffects;

    public void Init(Color color)
    {
        _onDieEffects = Instantiate(_onDieEffects);
        _onDieEffects.ChangeStartColor(color);
    }

    public void AnimateHit()
    {
        transform
            .DOScale(Vector3.one * _scaleAmount, _scaleTime)
            .OnComplete(() => transform.DORewind());
    }

    public void AnimateDie()
    {
        _onDieEffects.transform.position = transform.position;
        _onDieEffects.Play();
    }
}