using UnityEngine;
using Zenject;

public class BallEdgeDetector : ITickable
{
    private readonly Player _player;
    private readonly EdgeDetector _edgeDetector;
    private readonly BallsHandler _ballsHandler;
    
    public BallEdgeDetector(Player player, Camera cam, BallsHandler ballsHandler)
    {
        _player = player;
        _edgeDetector = new EdgeDetector(cam);
        _ballsHandler = ballsHandler;
    }

    public void Tick()
    {
        foreach (var ball in _ballsHandler.Balls)
        {
            if (_edgeDetector.IsOutsideEdge(ball.transform.position))
            {
                _player.ApplyDamage(ball.DamageOnDie);
                ball.DestroyThis();
            }
        }
    }
}