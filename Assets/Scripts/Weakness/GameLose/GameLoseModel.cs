using System;

public class GameLoseModel
{
    private readonly SceneManager _sceneManager;
    private readonly Player _player;
    private readonly TimeState _timeState;
    private readonly ScoreHandler _scoreHandler;
    private readonly BestScoreHandler _bestScoreHandler;

    public GameLoseModel(SceneManager sceneManager, Player player, TimeState timeState,
        ScoreHandler scoreHandler, BestScoreHandler bestScoreHandler)
    {
        _sceneManager = sceneManager;
        _player = player;
        _timeState = timeState;
        _scoreHandler = scoreHandler;
        _bestScoreHandler = bestScoreHandler;
    }

    public int CurrentScore => _scoreHandler.CurrentScore;
    public int BestScore => _bestScoreHandler.BestScore;

    public event Action OnLose;

    public void Enable()
    {
        _player.OnDie += OnLoseGame;
    }

    private void OnLoseGame()
    {
        _timeState.Stop();
        OnLose?.Invoke();
    }

    public void RestartGame()
    {
        _timeState.Resume();
        _sceneManager.ReloadScene();
    }

    public void Disable()
    {
        _player.OnDie -= OnLoseGame;
    }
}