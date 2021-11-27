using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BallEffects))]
[RequireComponent(typeof(BallRotater))]
[RequireComponent(typeof(BallMover))]

public class Ball : MonoBehaviour, IDamageable
{
    private float _health;
    private int _scoreOnDie;
    private int _damageOnDie;

    private SpriteRenderer _sprite;
    
    private BallEffects _ballEffects;
    private BallMover _ballMover;
    private BallRotater _ballRotater;

    public int ScoreOnDie => _scoreOnDie;
    public int DamageOnDie => _damageOnDie;

    public event Action<Ball> OnDestroyed;
    public event Action<Ball> OnKilled;

    public void Init(float health, float speed, int scoreOnDie, int damageOnDie, Color color, Vector3 angle)
    {
        _health = health;
        _scoreOnDie = scoreOnDie;
        _damageOnDie = damageOnDie;
        _sprite.color = color;
        
        _ballMover.Init(speed);
        _ballRotater.Init(angle);
        _ballEffects.Init(color);
    }

    public void ApplyDamage(int value)
    {
        _health -= value;

        if (_health > 0)
        {
            _ballEffects.AnimateHit();
        }
        else
        {
            DestroyThis();
            OnKilled?.Invoke(this);
        }
    }

    public void DestroyThis()
    {
        _ballEffects.AnimateDie();
        Destroy(gameObject);
    }

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _ballEffects = GetComponent<BallEffects>();
        _ballMover = GetComponent<BallMover>();
        _ballRotater= GetComponent<BallRotater>();
    }

    private void OnDestroy()
    {
        OnDestroyed?.Invoke(this);
    }
}