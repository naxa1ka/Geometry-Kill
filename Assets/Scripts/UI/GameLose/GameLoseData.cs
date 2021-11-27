public class GameLoseData
{
    private readonly ScoreHandler _scoreHandler;
    private readonly BestScoreHandler _bestScoreHandler;

    public int BestScore => _bestScoreHandler.BestScore;
    public int CurrentScore => _scoreHandler.CurrentScore;

    public GameLoseData(ScoreHandler scoreHandler, BestScoreHandler bestScoreHandler)
    {
        _scoreHandler = scoreHandler;
        _bestScoreHandler = bestScoreHandler;
    }
}