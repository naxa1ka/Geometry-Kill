public class GameLosePresenter
{
    private readonly GameLoseModel _model;
    private readonly GameLoseView _view;

    public GameLosePresenter(GameLoseModel model, GameLoseView view)
    {
        _model = model;
        _view = view;
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
        _view.Set(_model.CurrentScore, _model.BestScore);
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