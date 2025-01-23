namespace Tennis;

public class TennisGame1(string player1Name, string player2Name) : ITennisGame
{
    private int _player1Score = 0;
    private int _player2Score = 0;
    private readonly string _player1Name = player1Name;
    private readonly string _player2Name = player2Name;

    public void WonPoint(string playerName)
    {
        if (playerName == _player1Name)
            _player1Score += 1;
        else
            _player2Score += 1;
    }

    public string GetScore()
    {
        if (_player1Score == _player2Score)
        {
            return _player1Score switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce",
            };
        }

        if (_player1Score >= 4 || _player2Score >= 4)
        {
            var scoreDifference = _player1Score - _player2Score;
            return scoreDifference switch
            {
                1 => "Advantage player1",
                -1 => "Advantage player2",
                >= 2 => "Win for player1",
                _ => "Win for player2",
            };
        }

        return $"{GetScoreName(_player1Score)}-{GetScoreName(_player2Score)}";
    }

    private static string GetScoreName(int tempScore) => tempScore switch
    {
        0 => "Love",
        1 => "Fifteen",
        2 => "Thirty",
        _ => "Forty",
    };
}