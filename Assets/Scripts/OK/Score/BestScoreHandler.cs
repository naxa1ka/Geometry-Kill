using System;
using UnityEngine;
using Zenject;

public class BestScoreHandler : IInitializable, IDisposable
{
    private const string BestScoreKey = "BestScore";
    private readonly ScoreHandler _scoreHandler;
    
    private int _bestScore;
    
    public int BestScore => _bestScore;

    public BestScoreHandler(ScoreHandler scoreHandler)
    {
        _scoreHandler = scoreHandler;
    }

    public void Initialize()
    {
        _scoreHandler.OnScoreChanged += OnScoreChanged;
        _bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
    }

    private void OnScoreChanged(int score)
    {
        if (score > _bestScore)
        {
            _bestScore = score;
        }

        
    }

    public void Dispose()
    {
        PlayerPrefs.SetInt(BestScoreKey, _bestScore);
        PlayerPrefs.Save();
        
        _scoreHandler.OnScoreChanged -= OnScoreChanged;
    }
}