using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BallEffects))]
[RequireComponent(typeof(BallRotater))]
[RequireComponent(typeof(BallMover))]

public class Ball : MonoBehaviour
{
    private float _health;
    private int _scoreOnDie;
    private int _damageOnDie;

    private SpriteRenderer _sprite;
    
    private BallEffects _ballEffects;
    private BallMover _ballMover;

    public int ScoreOnDie => _scoreOnDie;
    public int DamageOnDie => _damageOnDie;

    public event Action<Ball> OnDied;

    public void Init(float health, float speed, int scoreOnDie, int damageOnDie, Color color)
    {
        _health = health;
        _scoreOnDie = scoreOnDie;
        _damageOnDie = damageOnDie;
        _sprite.color = color;
        
        _ballMover.Init(speed);
        _ballEffects.Init(color);
    }

    public bool TryToKill(int value)
    {
        _health -= value;

        if (_health < 0)
        {
            Die();
            return true;
        } 

        _ballEffects.AnimateHit();
        return false;
    }

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _ballEffects = GetComponent<BallEffects>();
        _ballMover = GetComponent<BallMover>();
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        _ballEffects.AnimateDie();
        OnDied?.Invoke(this);
    }
}