using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreText : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private ScoreHandler _scoreHandler;
    
    [Inject]   
    private void Constructor(ScoreHandler scoreHandler)
    {
        _scoreHandler = scoreHandler;
    }

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _scoreHandler.OnScoreChanged += OnScoreChanged;
    }

    private void Start()
    {
        InitStartValue();
    }

    private void InitStartValue()
    {
        UpdateText(_scoreHandler.CurrentScore);
    }

    private void OnScoreChanged(int score)
    {
        UpdateText(score);
    }

    private void UpdateText(int value)
    {
        _text.text = value.ToString();
    }
    
    private void OnDisable()
    {
        _scoreHandler.OnScoreChanged -= OnScoreChanged;
    }
}