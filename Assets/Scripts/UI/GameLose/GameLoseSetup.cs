using UnityEngine;
using Zenject;

public class GameLoseSetup : MonoBehaviour
{
    [SerializeField] private GameLoseView _view;

    private GameLosePresenter _presenter;
    private GameLoseModel _model;
    private GameLoseData _data;

    [Inject]
    private void Constructor(SceneManager sceneManager, Player player, TimeState timeState,
        ScoreHandler scoreHandler, BestScoreHandler bestScoreHandler)
    {
        _data = new GameLoseData(scoreHandler, bestScoreHandler);
        _model = new GameLoseModel(sceneManager, player, timeState);
        _presenter = new GameLosePresenter(_model, _data, _view);
    }

    private void OnEnable()
    {
        _presenter.Enable();
    }

    private void OnDisable()
    {
        _presenter.Disable();
    }
}