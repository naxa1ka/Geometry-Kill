using System;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CircleCollider2D))]
public class Ball : MonoBehaviour
{
    [Header("AnimationSettings")] 
    [SerializeField] private float _scaleAmount = 1.5f;
    [SerializeField] private float _scaleTime = 0.1f;
    [Space(10)] 
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private Vector3 _rotateAmount;
    [SerializeField] private float _randomAngle = 25f;
    [Space(10)]
    [SerializeField] private SubEmittersParticles _onDieEffects;
    
    private float _health;
    private float _speed;
    private int _scoreOnDie;
    private int _damageOnDie;

    private SpriteRenderer _sprite;

    public int ScoreOnDie => _scoreOnDie;
    public int DamageOnDie => _damageOnDie;

    public event Action<Ball> OnDied;

    public void Init(float health, float speed, int scoreOnDie, int damageOnDie, Color color)
    {
        _health = health;
        _speed = speed;
        _scoreOnDie = scoreOnDie;
        _damageOnDie = damageOnDie;
        _sprite.color = color;

        _onDieEffects = Instantiate(_onDieEffects);
        _onDieEffects.ChangeStartColor(color);
    }

    public bool TryToKill(int value)
    {
        _health -= value;

        if (_health < 0)
        {
            Die();
            return true;
        }

        AnimateHit();
        return false;
    }

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InitRandomAngle();
    }

    private void InitRandomAngle()
    {
        var randomAngle = Random.Range(-_randomAngle, _randomAngle);
        transform.eulerAngles = new Vector3(0f, 0f, randomAngle);
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(_rotateAmount * (_rotateSpeed * Time.deltaTime));
    }

    private void Move()
    {
        transform.Translate(Vector3.down * (_speed * Time.deltaTime));
    }

    private void AnimateHit()
    {
        transform
            .DOScale(Vector3.one * _scaleAmount, _scaleTime)
            .OnComplete(() => transform.DORewind());
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        _onDieEffects.transform.position = transform.position;
        _onDieEffects.Play();
        
        OnDied?.Invoke(this);
    }
}