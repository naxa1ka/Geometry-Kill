using System;
using Zenject;

public class BallDeathHandler : IInitializable, IDisposable
{
    private readonly BallsHandler _ballsHandler;
    private readonly ScoreHandler _scoreHandler;

    public BallDeathHandler(BallsHandler ballsHandler, ScoreHandler scoreHandler)
    {
        _ballsHandler = ballsHandler;
        _scoreHandler = scoreHandler;
    }
    
    public void Initialize()
    {
        _ballsHandler.OnBallKilled += OnBallKilled;
    }

    private void OnBallKilled(Ball ball)
    {
        _scoreHandler.AddScore(ball.ScoreOnDie);
    }

    public void Dispose()
    {
        _ballsHandler.OnBallKilled += OnBallKilled;
    }
}