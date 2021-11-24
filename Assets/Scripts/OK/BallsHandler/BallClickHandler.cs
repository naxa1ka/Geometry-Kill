using System;
using Zenject;

public class BallClickHandler: IInitializable, IDisposable
{
    private readonly BallDetector _ballDetector;
    private readonly Player _player;

    private const int DamagePerClick = 1;
    
    public BallClickHandler(BallDetector ballDetector, Player player)
    {
        _ballDetector = ballDetector;
        _player = player;
    }

    public void Initialize()
    {
        _ballDetector.OnBallClicked += OnBallClicked;
        _player.OnDie += DisableInput;
    }

    private void DisableInput()
    {
        _ballDetector.OnBallClicked -= OnBallClicked;
    }

    private void OnBallClicked(Ball ball)
    {
        ball.ApplyDamage(DamagePerClick);
    }

    public void Dispose()
    {
        _player.OnDie -= DisableInput;
        _ballDetector.OnBallClicked -= OnBallClicked;
    }

   
}