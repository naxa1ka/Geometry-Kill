using System;
using UnityEngine;
using Zenject;

public class BallDetector : IInitializable, IDisposable
{
    private readonly IInput _input;
    private readonly Camera _camera;

    public event Action<Ball> OnBallClicked;
    
    public BallDetector(Camera cam, IInput input)
    {
        _input = input;
        _camera = cam;
    }

    public void Initialize()
    {
        _input.OnClick += OnClick;
    }

    private void OnClick(Vector3 position)
    {
        var worldPosition = _camera.ScreenToWorldPoint(position);
        var hit = Physics2D.Raycast(worldPosition, Vector2.down);

        if (hit.collider != null)
        {
            if (hit.collider.TryGetComponent<Ball>(out var ball))
            {
                OnBallClicked?.Invoke(ball);
            }
        }
    }

    public void Dispose()
    {
        _input.OnClick -= OnClick;
    }
}