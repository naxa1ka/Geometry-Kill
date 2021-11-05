using System;
using Zenject;

public class BallDamager: IInitializable, IDisposable
{
    private readonly BallDetector _ballDetector;
    private readonly ScoreHandler _scoreHandler;

    private const int DamagePerClick = 1;
    
    public BallDamager(ScoreHandler scoreHandler, BallDetector ballDetector)
    {
        _scoreHandler = scoreHandler;
        _ballDetector = ballDetector;
    }

    public void Initialize()
    {
        _ballDetector.OnBallClicked += OnBallClicked;
    }
    
    private void OnBallClicked(Ball ball)
    {
        if (ball.TryToKill(DamagePerClick))
        {
            _scoreHandler.AddScore(ball.ScoreOnDie);
        }
    }

    public void Dispose()
    {
        _ballDetector.OnBallClicked += OnBallClicked;
    }

   
}