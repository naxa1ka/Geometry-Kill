using System;
using System.Collections.Generic;
using Zenject;

public class BallsHandler : IInitializable, IDisposable
{
    private readonly Spawner _spawner;

    private readonly LinkedList<Ball> _balls = new LinkedList<Ball>();
    public IReadOnlyCollection<Ball> Balls => _balls;

    public event Action<Ball> OnBallKilled;
    
    public BallsHandler(Spawner spawner)
    {
        _spawner = spawner;
    }
    
    public void Initialize()
    {
        _spawner.OnBallSpawned += OnBallSpawned;
    }

    private void OnBallSpawned(Ball ball)
    {
        Add(ball);
    }

    private void Add(Ball ball)
    {
        _balls.AddLast(ball);
        
        ball.OnKilled += OnKilled;
        ball.OnDestroyed += Remove;
    }

    private void OnKilled(Ball ball)
    {
        OnBallKilled?.Invoke(ball);
    }

    private void Remove(Ball ball)
    {
        ball.OnKilled -= OnKilled;
        ball.OnDestroyed -= Remove;
        
        _balls.Remove(ball);
    }
    
    public void Dispose()
    {
        _spawner.OnBallSpawned -= OnBallSpawned;
    }
}