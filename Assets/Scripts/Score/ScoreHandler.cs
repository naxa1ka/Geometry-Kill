using System;

public class ScoreHandler
{
    private int _currentScore;
    
    public int CurrentScore => _currentScore;
    
    public event Action<int> OnScoreChanged;
    
    public void AddScore(int value)
    {
        _currentScore += value;
        OnScoreChanged?.Invoke(_currentScore);
    }
}