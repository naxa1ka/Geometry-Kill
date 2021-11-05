using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class PausePanelView : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _pauseButton;
    
    private CanvasGroup _canvasGroup;
    
    public event Action OnPause;
    public event Action OnRestart;
    public event Action OnPlay;

    private void OnEnable()
    {
        _pauseButton.onClick.AddListener(OnPauseButtonClick);
        _restartButton.onClick.AddListener(OnRestartClick);
        _playButton.onClick.AddListener(OnPlayClick);
    }

    private void OnPauseButtonClick()
    {
        OnPause?.Invoke();
    }

    private void OnRestartClick()
    {
        OnRestart?.Invoke();
    }

    private void OnPlayClick()
    {
        OnPlay?.Invoke();
    }

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Open()
    {
        _canvasGroup.Open();
    }

    public void Close()
    {
        _canvasGroup.Close();
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartClick);
        _playButton.onClick.RemoveListener(OnPlayClick);
    }
}