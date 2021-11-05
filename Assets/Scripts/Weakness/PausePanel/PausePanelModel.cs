public class PausePanelModel
{
    private readonly SceneManager _sceneManager;
    private readonly TimeState _timeState;

    public PausePanelModel(SceneManager sceneManager, TimeState timeState)
    {
        _sceneManager = sceneManager;
        _timeState = timeState;
    }

    public void PauseGame()
    {
        _timeState.Stop();
    }
    
    public void PlayGame()
    {
        _timeState.Resume();
    }

    public void RestartGame()
    {
        _timeState.Resume();
        _sceneManager.ReloadScene();
    }
}