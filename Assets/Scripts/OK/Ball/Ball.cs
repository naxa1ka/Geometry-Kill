using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(BallEffects))]

public class Ball : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private Vector3 _rotateAmount;
    [SerializeField] private float _randomAngle = 25f;
    
    private float _health;
    private float _speed;
    private int _scoreOnDie;
    private int _damageOnDie;

    private SpriteRenderer _sprite;
    private BallEffects _ballEffects;

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

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        _ballEffects.OnDie();
        OnDied?.Invoke(this);
    }
}