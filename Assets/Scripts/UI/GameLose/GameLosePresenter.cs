public class GameLosePresenter
{
    private readonly GameLoseModel _model;
    private readonly GameLoseView _view;
    private readonly GameLoseData _data;

    public GameLosePresenter(GameLoseModel model, GameLoseData data, GameLoseView view)
    {
        _model = model;
        _view = view;
        _data = data;
    }

    public void Enable()
    {
        _model.Enable();
        _model.OnLose += OnLose;
        
        _view.OnContinue += OnContinue;
    }

    private void OnLose()
    {
        _view.Open();
        _view.Set(_data.CurrentScore, _data.BestScore);
    }

    private void OnContinue()
    {
        _view.Close();
        _model.RestartGame();
    }

    public void Disable()
    {
        _model.Disable();
        _model.OnLose -= OnLose;
        
        _view.OnContinue -= OnContinue;
    }
}