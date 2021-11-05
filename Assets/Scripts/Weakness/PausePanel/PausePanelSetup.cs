using UnityEngine;
using Zenject;

public class PausePanelSetup : MonoBehaviour
{
    [SerializeField] private PausePanelView _view;

    private PausePanelPresenter _presenter;
    private PausePanelModel _model;

    [Inject]
    private void Constructor(SceneManager sceneManager, TimeState timeState)
    {
        _model = new PausePanelModel(sceneManager, timeState);
        _presenter = new PausePanelPresenter(_model, _view);
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