using System;
using Zenject;

public class BallClickHandler: IInitializable, IDisposable
{
    private readonly BallDetector _ballDetector;

    private const int DamagePerClick = 1;
    
    public BallClickHandler(BallDetector ballDetector)
    {
        _ballDetector = ballDetector;
    }

    public void Initialize()
    {
        _ballDetector.OnBallClicked += OnBallClicked;
    }
    
    private void OnBallClicked(Ball ball)
    {
        ball.ApplyDamage(DamagePerClick);
    }

    public void Dispose()
    {
        _ballDetector.OnBallClicked += OnBallClicked;
    }

   
}