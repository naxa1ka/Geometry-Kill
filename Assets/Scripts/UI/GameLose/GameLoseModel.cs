using System;

public class GameLoseModel
{
    private readonly SceneManager _sceneManager;
    private readonly Player _player;
    private readonly TimeState _timeState;

    public GameLoseModel(SceneManager sceneManager, Player player, TimeState timeState)
    {
        _sceneManager = sceneManager;
        _player = player;
        _timeState = timeState;
    }

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